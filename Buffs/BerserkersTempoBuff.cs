using UnityEngine;

public class BerserkersTempoBuff : StatusEffect
{
    // Increase attack speed by a percentage
    public float attackSpeedIncrease;

    public BerserkersTempoBuff(float attackSpeedIncrease, int duration, int howOften) : base("Berserkers Tempo", duration, howOften, StatusEffectType.Buff)
    {
        this.attackSpeedIncrease = attackSpeedIncrease;
    }

    public override void OnApply(Fighter target)
    {
        Debug.Log(target.unitName + " BUFF GOT APPLIED THIS IS FROM OnApply");
    }

    public override void OnTimer(Fighter target)
    {
        target.attackSpeed *= attackSpeedIncrease;
        Debug.Log("Trying to increase attack speed");
        
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log("Berserkers Tempo expired");
    }
}
