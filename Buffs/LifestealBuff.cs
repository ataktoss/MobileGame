using UnityEngine;

public class LifestealBuff : StatusEffect
{
    public float leechAmount;

    public LifestealBuff(float leechAmount, int duration, int howOften) : base("Lifesteal", duration, howOften, StatusEffectType.Buff)
    {
        this.leechAmount = leechAmount;
    }

    public override void OnAttack(Fighter target, int damage)
    {
        target.Heal(Mathf.RoundToInt(damage * leechAmount));
    }

    public override void OnApply(Fighter target)
    {
        // Logic for applying the lifesteal buff
    }

    public override void OnTimer(Fighter target)
    {
        // Logic for the buff's periodic effect
    }

    public override void OnExpire(Fighter target)
    {
        // Logic for when the buff expires
    }
}

