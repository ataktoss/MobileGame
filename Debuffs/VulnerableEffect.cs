using UnityEngine;

public class VulnerableEffect : StatusEffect
{

    float damageTakenAmount;
    public VulnerableEffect(int duration, int howOften, float damageTakenAmount) : base("Vulnerable", duration, howOften, StatusEffectType.Debuff)
    {
        this.damageTakenAmount = damageTakenAmount;
    }

    public override void OnApply(Fighter target)
    {
        target.damageTakenModifiers.Add((damage) => Mathf.CeilToInt(damage * damageTakenAmount));
    }


}
