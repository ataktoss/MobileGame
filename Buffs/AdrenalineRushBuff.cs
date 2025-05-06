using UnityEngine;

public class AdrenalineRushBuff : StatusEffect
{
    public float attackSpeedModifier;

    public AdrenalineRushBuff(float attackSpeedBoost, int duration, int howOften): base("AttackSpeedBoost",duration,howOften){
        this.attackSpeedModifier = attackSpeedBoost;
    }

    public override void OnAPply(IFighter target)
    {
        target.attackSpeed *= 1+attackSpeedModifier;
        Debug.Log(target.unitName + " Now has modified attack speed");
    }

    public override void OnTimer(IFighter target)
    {
        
    }

    public override void OnExpire(IFighter target)
    {
        target.attackSpeed = Mathf.RoundToInt(target.attackSpeed/(1+attackSpeedModifier));
        Debug.Log(target.name + " no longer has modified attack speed");
    }
}
