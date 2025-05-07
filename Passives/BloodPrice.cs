using UnityEngine;

public class BloodPrice : Passive,IEffect
{
    
    public BloodPrice():base("Blood Price","Deal +10% damage but take 5 damage very 5 seconds"){}

    public void Apply(IFighter caster, IFighter target)
    {
        
    }


    public override void ApplyEffect(IFighter fighter)
    {
        fighter.ApplyDebuff(new BloodPriceEffect(5,100,5));
    }
}
