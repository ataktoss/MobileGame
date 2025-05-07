using UnityEngine;

public class SilenceEffect : StatusEffect
{
    public SilenceEffect(int duration,int howOften): base("Silence",duration,howOften,StatusEffectType.Debuff){
        
    }

    public override void OnAPply(IFighter target)
    {
        Debug.Log(target.unitName + " Is now Silenced");
        target.isSilenced = true;
    }

    public override void OnTimer(IFighter target)
    {
        
    }

    public override void OnExpire(IFighter target)
    {
        target.isSilenced = false;
        Debug.Log(target.name + "Is no longer burning");
    }
}
