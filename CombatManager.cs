using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class CombatManager : MonoBehaviour
{

    public List<GameObject> heroObjects = new();
    //Use heroes for combat stuff
    public List<IFighter> heroes = new List<IFighter>();
    
    public List<IFighter> monsters = new List<IFighter>();
    public List<Transform> enemySpawnPoints; 
    public List<Transform> heroSpawnPoints; 
    public static CombatManager Instance {get; private set;}
    
    private float timer = 0f;
    private Coroutine combatLoop;
    private EncounterGroupSO currentEncounter;
    public EncounterGroupSO CurrentEncounter{
        get=>currentEncounter;
        set{
            currentEncounter = value;
            //DO STUFF LIKE PREPARE COMBAT HERE
        }
    }

    
    
    

    IEnumerator<System.Object> UpdateCombatLoop(){
        while(true){
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
            foreach(var monster in monsters){
                
                if (monster != null)
                {
                    HandleCombatAI(monster, heroes);
                    monster.TickStatusEffects();
                }
            }
            yield return new WaitForSeconds(0.1f); //Update Combat timer
        }
    }

    void HandleCombatAI(IFighter fighter,List<IFighter> enemies){

        
        if(fighter == null || !fighter.isAlive){
            return;
        }
        IFighter target = GetClosestTarget(fighter.transform.position, enemies);
        if(target == null){
            return;
        }
        fighter.currentTarget = target;
        float distance = Vector3.Distance(fighter.transform.position,target.transform.position);
        if(fighter.melee){
            if(distance>fighter.attackRange){
                fighter.MoveToward(target.transform.position);
            }
            else{
                fighter.StartAttack(target);
            }
        }
        else{
            if(distance<=fighter.attackRange){
                fighter.StartAttack(target);
            }
        }
    }

    IFighter GetClosestTarget(Vector3 fromPosition, List<IFighter> targets){

        IFighter closest = null;
        float minDist = float.MaxValue;

        foreach(var target in targets){
            if(target == null || !target.isAlive) continue;
            float dist = Vector3.Distance(fromPosition, target.transform.position);
            if(dist<minDist){
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

            IFighter fighterRef = instance.GetComponent<IFighter>();
            if (fighterRef != null)
            {
                monsters.Add(fighterRef);
                UnityEngine.Debug.Log("Added " + fighterRef.name + " to enemy List");
            }



        }
        if (currentEncounter.type == EncounterType.Normal)
        {
            UnityEngine.Debug.Log("THE CURRENT ENCOUNTER IS OF NORMAL TYPE");
        }
        //SET HEROES
        for (int i = 0; i < heroObjects.Count && i < heroSpawnPoints.Count; i++)
        {
            GameObject prefab = heroObjects[i];
            Transform spawnPoint = heroSpawnPoints[i];
            GameObject instance = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            instance.transform.SetParent(spawnPoint);

            IFighter fighterRef = instance.GetComponent<IFighter>();
            if (fighterRef != null)
            {
                heroes.Add(fighterRef);
                UnityEngine.Debug.Log("Added " + fighterRef.name + " to enemy List");
            }



        }
    }

    



    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        
    }

    public void StartCombat(){
        // foreach (var hero in heroObjects)
        // {
        //     heroes.Add(hero.GetComponent<IFighter>());


        // }
        GameManager.Instance.ChangeState(GameManager.GameState.Combat);
        combatLoop = StartCoroutine(UpdateCombatLoop());
    }
    private void EndCombat()
    {
        UnityEngine.Debug.Log("END COMBAT FUNCTION HERE");
        //StopCoroutine(combatLoop);
        foreach (var hero in heroes)
        {
            
            Destroy(hero.gameObject);
        }
        heroes.Clear();
        monsters.Clear();
        GameManager.Instance.ChangeState(GameManager.GameState.combatReward);

    }

    public void AddHero(GameObject hero)
    {
        heroObjects.Add(hero);
        UnityEngine.Debug.Log("Just added the Hero " + hero.name);
    }
    public List<IFighter> GetHeroList()
    {
        return heroes;
    }
    public List<IFighter> GetMonsterList(){
        return monsters;
    }


}
