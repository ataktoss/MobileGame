using Unity.Mathematics;
using UnityEngine;

public class FeastOnPain : Passive
{
    public FeastOnPain():base("Feast On Pain","Heal for 10% of damage done with Attacks"){}

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }

    public override void OnAttack(IFighter fighter, IFighter target, int damage)
    {
        int healAmount = Mathf.RoundToInt(damage *1.1f);
        if(fighter){
            fighter.Heal(healAmount);
        }
    }

    
}
