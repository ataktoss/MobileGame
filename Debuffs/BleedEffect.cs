using UnityEngine;

public class BleedEffect : StatusEffect
{
    public int damagePerTurn;

    public BleedEffect(int damagePerTurn, int duration, int howOften) : base("Bleed", duration, howOften, StatusEffectType.Debuff)
    {
        this.damagePerTurn = damagePerTurn;
    }

    public override void OnApply(Fighter target)
    {
        
    }

    public override void OnTimer(Fighter target)
    {
        if(target == null) return;
        target.TakeDamage(damagePerTurn,target);
        
    }

    public override void OnExpire(Fighter target)
    {
        
    }
}
