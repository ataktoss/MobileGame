using UnityEngine;

public class AttackSpeedBuff : StatusEffect
{
    public int attackSpeedModifier;

    public AttackSpeedBuff(int attackSpeedBoost, int duration, int howOften): base("AttackSpeedBoost",duration,howOften,StatusEffectType.Buff){
        this.attackSpeedModifier = attackSpeedBoost;
    }

    public override void OnAPply(Fighter target)
    {
        target.attackSpeed = Mathf.RoundToInt(target.attackSpeed * (1+attackSpeedModifier));
        Debug.Log(target.unitName + " Now has modified attack speed");
    }

    public override void OnTimer(Fighter target)
    {
        
    }

    public override void OnExpire(Fighter target)
    {
        target.attackSpeed = Mathf.RoundToInt(target.attackSpeed/(1+attackSpeedModifier));
        Debug.Log(target.name + " no longer has modified attack speed");
    }

}
