using UnityEngine;

public class BlightedEcho : Passive, IEffect
{

    public BlightedEcho():base("Blighted Echo","Chance on hit to silence"){}



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        if(Random.value < 0.30f){
            target.ApplyDebuff(new SilenceEffect(3,1));
        }
    }

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
