using Unity.Mathematics;
using UnityEngine;

public class FeastOnPain : Passive
{
    public FeastOnPain():base("Feast On Pain","Heal for 10% of damage done with Attacks"){}

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        int healAmount = Mathf.RoundToInt(damage *1.1f);
        if(fighter){
            fighter.Heal(healAmount);
        }
    }

    
}
