using UnityEngine;

public class Deflect: Passive
{
    public Deflect():base("Deflect","+10% chance to reflect damage current target"){}

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void OnTakeDamage(IFighter fighter, int damage)
    {
        if(Random.value <0.10f){
            if(fighter.currentTarget != null){
                fighter.currentTarget.TakeDamage(damage);
            }
        }
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }
}
