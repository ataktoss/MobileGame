using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    
    
    public List<IFighter> heroes = new List<IFighter>();
    public List<IFighter> monsters = new List<IFighter>();
    
    
    private float timer = 0f;
    
    
    void Start()
    {
        StartCoroutine(UpdateCombatLoop());
    }

    IEnumerator<System.Object> UpdateCombatLoop(){
        while(true){
            yield return null;

            foreach(var fighter in heroes){
                HandleCombatAI(fighter,monsters);
                fighter.TickStatusEffects();
            }
            foreach(var monster in monsters){
                HandleCombatAI(monster,heroes);
                monster.TickStatusEffects();
            }
            yield return new WaitForSeconds(0.2f); //Update Combat timer
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


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if(timer>= )
    }
}
