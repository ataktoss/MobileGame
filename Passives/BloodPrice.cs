using UnityEngine;

public class BloodPrice : Passive,IEffect
{
    //Gain 10% damage but take 5 damage every 5 seconds
    public BloodPrice(PassiveData data) : base(data)
    {

    }

    public void Apply(Fighter caster, Fighter target)
    {
        
    }


    public override void ApplyEffect(Fighter fighter)
    {
        fighter.ApplyDebuff(new BloodPriceEffect(5,100,5));
    }
}
