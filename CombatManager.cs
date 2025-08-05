using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class HeroRuntimeData
{
    public GameObject prefab; // The hero type (used to instantiate)
    public List<ItemData> equippedItems = new();
    public List<Passive> passives = new();
    public string nickname;
    public int level = 1;
    public int currentXP = 0;


    // You can extend this later with talents, stats, etc.
}



public class CombatManager : MonoBehaviour
{


    public List<HeroRuntimeData> currentTeam = new();
    public List<GameObject> heroObjects = new();
    //Use heroes for combat stuff
    public List<Fighter> heroes = new List<Fighter>();

    public List<Fighter> monsters = new List<Fighter>();
    public List<Transform> enemySpawnPoints;
    public List<Transform> heroSpawnPoints;
    public static CombatManager Instance { get; private set; }
    public Button startCombatButton;
    public GameObject starterHeroprefab;
    public PassiveDatabase passiveDatabase;

    private float timer = 0f;
    private Coroutine combatLoop;
    private EncounterGroupSO currentEncounter;
    public EncounterGroupSO CurrentEncounter
    {
        get => currentEncounter;
        set
        {
            currentEncounter = value;
            //DO STUFF LIKE PREPARE COMBAT HERE
        }
    }

    private float combatScale = 1;

    public int playerGold = 50;

    public bool SpendGold(int amount)
    {
        if (amount <= playerGold)
        {
            playerGold -= amount;
            UnityEngine.Debug.Log("Spent " + amount + " gold.");
            return true;
        }
        else
        {
            UnityEngine.Debug.Log("Not enough gold.");
            return false;
        }
    }

    IEnumerator<System.Object> UpdateCombatLoop()
    {
        while (true)
        {
            yield return null;
            if (monsters.All(m => m == null))
            {
                EndCombat();
                UnityEngine.Debug.Log("Ending combat from loop");
                yield break;
            }

            foreach (var fighter in heroes)
            {
                HandleCombatAI(fighter, monsters);
                fighter.TickStatusEffects();
            }
            foreach (var monster in monsters)
            {

                if (monster != null)
                {
                    HandleCombatAI(monster, heroes);
                    monster.TickStatusEffects();
                }
            }
            yield return new WaitForSeconds(0.1f); //Update Combat timer
        }
    }

    void HandleCombatAI(Fighter fighter, List<Fighter> enemies)
    {


        if (fighter == null || !fighter.isAlive)
        {
            return;
        }
        Fighter target = GetClosestTarget(fighter.transform.position, enemies);
        if (target == null)
        {
            return;
        }
        fighter.currentTarget = target;
        float distance = Vector3.Distance(fighter.transform.position, target.transform.position);
        if (fighter.melee)
        {
            if (distance > fighter.attackRange)
            {
                fighter.MoveToward(target.transform.position);
            }
            else
            {
                fighter.StartAttack(target);
            }
        }
        else
        {
            if (distance <= fighter.attackRange)
            {
                fighter.StartAttack(target);
            }
        }
    }

    Fighter GetClosestTarget(Vector3 fromPosition, List<Fighter> targets)
    {

        Fighter closest = null;
        float minDist = float.MaxValue;

        foreach (var target in targets)
        {
            if (target == null || !target.isAlive) continue;
            float dist = Vector3.Distance(fromPosition, target.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = target;
            }
        }
        return closest;



    }

    public void AsignEnemiesAndHeroes()
    {
        //SET ENEMIES
        for (int i = 0; i < currentEncounter.enemyPrefabs.Count && i < enemySpawnPoints.Count; i++)
        {
            GameObject prefab = currentEncounter.enemyPrefabs[i];
            Transform spawnPoint = enemySpawnPoints[i];
            GameObject instance = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            instance.transform.SetParent(spawnPoint);

            Fighter fighterRef = instance.GetComponent<Fighter>();
            if (fighterRef != null)
            {

                monsters.Add(fighterRef);
                ScaleMonsters(fighterRef);
                UnityEngine.Debug.Log("Added " + fighterRef.name + " to enemy List");
            }



        }
        if (currentEncounter.type == EncounterType.Normal)
        {
            UnityEngine.Debug.Log("THE CURRENT ENCOUNTER IS OF NORMAL TYPE");
        }
        //SET HEROES
        for (int i = 0; i < currentTeam.Count && i < heroSpawnPoints.Count; i++)
        {
            GameObject prefab = currentTeam[i].prefab;
            Transform spawnPoint = heroSpawnPoints[i];
            GameObject instance = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            instance.transform.SetParent(spawnPoint);

            Fighter fighterRef = instance.GetComponent<Fighter>();
            if (fighterRef != null)
            {
                heroes.Add(fighterRef);
                UnityEngine.Debug.Log("Added " + fighterRef.name + " to hero List");
                foreach (var item in currentTeam[i].equippedItems)
                {
                    fighterRef.EquipItem(item);
                }
                foreach (var passive in currentTeam[i].passives)
                {
                    fighterRef.AddPassive(passive);
                }
            }
        }
        //SCALE ENEMIES
        combatScale += 0.1f;
        UnityEngine.Debug.Log("Combat scale is now: " + combatScale);
    }

    void ScaleMonsters(Fighter monster)
    {
        if (monster == null) return;

        // Scale the monster's stats based on the combat scale
        monster.life = Mathf.RoundToInt(monster.life * combatScale);
        monster.attackDamage = Mathf.RoundToInt(monster.attackDamage * combatScale);
        

        
    }

    void Start()
    {
        startCombatButton.onClick.AddListener(StartCombat);
        AddHero(starterHeroprefab);
    }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }


    void Update()
    {
        timer += Time.deltaTime;


    }

    public void SetupCombat()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Combat);
        startCombatButton.gameObject.SetActive(true);
    }
    public void StartCombat()
    {

        //GameManager.Instance.ChangeState(GameManager.GameState.Combat);
        combatLoop = StartCoroutine(UpdateCombatLoop());
        startCombatButton.gameObject.SetActive(false);
    }
    private void EndCombat()
    {
        UnityEngine.Debug.Log("END COMBAT FUNCTION HERE");
        //StopCoroutine(combatLoop);
        foreach (var hero in heroes)
        {
            if (hero.gameObject == null) continue;
            Destroy(hero.gameObject);
        }
        heroes.Clear();
        monsters.Clear();

        for (int i = 0; i < currentTeam.Count; i++)
        {
            currentTeam[i].currentXP += 2;
            if (currentTeam[i].currentXP >= 3) // Example level up condition
            {
                currentTeam[i].level++;
                currentTeam[i].currentXP = 0; // Reset XP after leveling up
                //UnityEngine.Debug.Log($"{currentTeam[i].prefab.GetComponent<Fighter>().unitName} leveled up to level {currentTeam[i].level}!");
                currentTeam[i].prefab.GetComponent<Fighter>().LevelUp();

                if (currentTeam[i].level == 3)
                {
                    //CombatRewards.Instance.GeneratePassiveRewards(i);
                }

                //GameManager.Instance.ChangeState(GameManager.GameState.passiveChoice);        
            }
        }
        GameManager.Instance.ChangeState(GameManager.GameState.combatReward);
        playerGold += 5;
    }

    public void AddHero(GameObject hero)
    {
        HeroRuntimeData newHero = new();
        newHero.prefab = hero;
        currentTeam.Add(newHero);
        UnityEngine.Debug.Log("Just added the Hero " + hero.name);
    }
    public void GivePassive(int whichHero, Passive passive)
    {
        currentTeam[whichHero].passives.Add(passive);
        UnityEngine.Debug.Log($"Added passive {passive.passiveName} to hero {currentTeam[whichHero].prefab.GetComponent<Fighter>().unitName}");
    }
    public List<Fighter> GetHeroList()
    {
        UnityEngine.Debug.Log($"Fighter count: {heroes.Count}");
        return heroes;
    }
    public List<Fighter> GetMonsterList()
    {
        return monsters;
    }
    public List<HeroRuntimeData> GetCurrentTeamInfo()
    {
        UnityEngine.Debug.Log("Returning hero objects");
        return currentTeam;
    }


}
