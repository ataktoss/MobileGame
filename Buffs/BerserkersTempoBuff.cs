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
        
    }

    public override void OnTimer(Fighter target)
    {
        target.attackSpeed /= attackSpeedIncrease;
        
    }

    public override void OnExpire(Fighter target)
    {
        //target.attackSpeed /= (1 + attackSpeedIncrease);
    }
}
