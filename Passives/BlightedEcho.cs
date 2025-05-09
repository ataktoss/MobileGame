using UnityEngine;

public class BlightedEcho : Passive, IEffect
{

    public BlightedEcho():base("Blighted Echo","Chance on hit to silence"){}



    public override void OnAttack(IFighter fighter, IFighter target, int damage)
    {
        if(Random.value < 0.30f){
            target.ApplyDebuff(new SilenceEffect(3,1));
        }
    }

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }
}
