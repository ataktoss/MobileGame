using UnityEngine;

public class FreezeEffect: StatusEffect
{
    public FreezeEffect(int duration,int howOften): base("Burn",duration,howOften,StatusEffectType.Debuff){
        
    }

    public override void OnAPply(Fighter target)
    {
        Debug.Log(target.unitName + " Is now Frozen");
        target.isFrozen = true;
    }

    public override void OnTimer(Fighter target)
    {
        
    }

    public override void OnExpire(Fighter target)
    {
        target.isFrozen = false;
        Debug.Log(target.name + "Is no longer burning");
    }
}
