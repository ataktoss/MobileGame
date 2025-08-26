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
    [SerializeReference] public List<Passive> passives = new();
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

    private int currentAct = 1;
    private int numberOfEncounters = 1;
    private float enemyLifeScaling = 1f;
    private float enemyDamageScaling = 1f;

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
        SetTankFirst();
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

        enemyLifeScaling += 0.18f;
        enemyDamageScaling += 0.18f;
        
    }
    private void SetTankFirst()
    {
        for (int i = 0; i < currentTeam.Count; i++)
        {
            if (currentTeam[i].prefab.GetComponent<Fighter>().fighterType == FighterType.Tank)
            {
                // Set the tank as the first fighter in the list
                HeroRuntimeData tank = currentTeam[i];
                currentTeam.RemoveAt(i);
                currentTeam.Insert(0, tank);
                UnityEngine.Debug.Log("Tank set as first fighter: " + tank.prefab.name);
                break;
            }
            
        }
    }

    //this is triggered before the monster start method
    void ScaleMonsters(Fighter monster)
    {
        if (monster == null) return;

        // Scale the monster's stats based on the combat scale
        float actScaling = 1;
        switch (currentAct)
        {
            case 1:
                actScaling = 1f;
                break;
            case 2:
                actScaling = 1.5f;
                break;
            case 3:
                actScaling = 2f;
                break;
            
            default:
                actScaling = 1f;
                break;
        }
        if (numberOfEncounters > 3)
        {

            monster.baseLife = Mathf.RoundToInt(monster.baseLife * enemyLifeScaling * actScaling * 1.5f);
            UnityEngine.Debug.Log("The monsters base life is : " + monster.baseLife + " and their current life is now : " + monster.life);
            monster.baseAttackDamage = Mathf.RoundToInt(monster.baseAttackDamage * enemyDamageScaling * 1.5f);
        }
        else
        {
            monster.baseLife = Mathf.RoundToInt(monster.baseLife * actScaling * enemyLifeScaling);
            UnityEngine.Debug.Log("The monsters base life is : " + monster.baseLife + " and their current life is now : " + monster.life);
            monster.baseAttackDamage = Mathf.RoundToInt(monster.baseAttackDamage * enemyDamageScaling);
        }

        
    }

    public Dictionary<string, int> damageDone = new();
    [SerializeField] private TMPro.TextMeshProUGUI dpsText;
    public void RegisterDamage(Fighter attacker, int amount)
    {
        if (attacker == null) return;

        string key = attacker.unitName;
        if (!damageDone.ContainsKey(key))
        {
            damageDone[key] = 0;
        }
            

        damageDone[key] += amount;

        UpdateDpsUI();


    }
    private void UpdateDpsUI()
    {
        if (dpsText == null) return;

        string text = "Damage Done:\n";

        // Order by value descending
        foreach (var kvp in damageDone.OrderByDescending(x => x.Value))
        {
            text += $"{kvp.Key}: {kvp.Value}\n";
        }

        dpsText.text = text;
    }



    void Start()
    {
        startCombatButton.onClick.AddListener(StartCombat);
        AddHero(CombatRewards.Instance.heroDatabase.GetRandomHero());
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

        foreach (var hero in heroes)
        {
            if (hero == null) continue;
            hero.PrepareForCombat();
        }
        foreach (var monster in monsters)
        {
            if (monster == null) continue;
            monster.PrepareForCombat();
        }


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
            if (!hero) continue;
            Destroy(hero.gameObject);
        }
        heroes.Clear();
        monsters.Clear();

        
        if (currentEncounter.type == EncounterType.Boss)
        {
            currentAct++;
            UnityEngine.Debug.Log("Current Act: " + currentAct);
            if (currentAct == 2)
            {
                CombatRewards.Instance.GeneratePassives();
                
            }
            
            CombatRewards.Instance.choseBossItem();
            MapUIManager.Instance.GenerateMap();
            UnityEngine.Debug.Log("ENDING COMBAT AND RESETTING THE MAP");
            
            
        }

        GameManager.Instance.ChangeState(GameManager.GameState.combatReward); //Afto tha einai aplos gia background eno epilegeis items. Isos einai useless na iparxei 
        if(currentEncounter.type == EncounterType.Normal || currentEncounter.type == EncounterType.Elite)
        {
            if (numberOfEncounters < 3)
            {
                CombatRewards.Instance.choseHero();
            }
            else
            {
                CombatRewards.Instance.choseItem();
            }
        }
        
        
        numberOfEncounters++;
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
