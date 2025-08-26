using Unity.VisualScripting;
using UnityEngine;

public class HealOnDamagePassive : Passive
{


    int fighterLife;

    public HealOnDamagePassive():base(
        "Second Wind",
        "When you take damage Heal"
    ){}


    // public void OnTakeDamage(IFighter fighter, int damage){

    // }
    public override void OnAttack(Fighter fighter, Fighter target, int damage){
        ApplyEffect(fighter);
    }


    public override void OnTakeDamage(Fighter fighter,Fighter target, int damage)
    {
        //base.OnTakeDamage(fighter, damage);
        fighterLife = fighter._currentLife;
        
        if(fighterLife<50){
            fighter.Heal(5);
        }
    }
    public override void ApplyEffect(Fighter fighter)
    {
        Debug.Log("This part worked");
        fighter.CustomEffect(()=>{
            Debug.Log("HEAL ON DAMAGE PASSIVE WORKED");
        });

    }
    
}
