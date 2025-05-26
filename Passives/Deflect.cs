using UnityEngine;

public class Deflect: Passive
{
    public Deflect():base("Deflect","+10% chance to reflect damage current target"){}

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        if(Random.value <0.10f){
            if(fighter.currentTarget != null){
                fighter.currentTarget.TakeDamage(damage);
            }
        }
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
