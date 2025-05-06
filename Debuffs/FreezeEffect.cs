using UnityEngine;

public class FreezeEffect: StatusEffect
{
    public FreezeEffect(int duration,int howOften): base("Burn",duration,howOften){
        
    }

    public override void OnAPply(IFighter target)
    {
        Debug.Log(target.unitName + " Is now Frozen");
        target.isFrozen = true;
    }

    public override void OnTimer(IFighter target)
    {
        
    }

    public override void OnExpire(IFighter target)
    {
        target.isFrozen = false;
        Debug.Log(target.name + "Is no longer burning");
    }
}
