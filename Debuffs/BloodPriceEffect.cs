using UnityEngine;

public class BloodPriceEffect:StatusEffect
{
    public int damagePerTurn;
    public BloodPriceEffect(int damagePerTurn,int duration,int howOften):base("Take damage but deal more damage",duration,howOften,StatusEffectType.Debuff){
        this.damagePerTurn = damagePerTurn;
    }

    public override void OnAPply(Fighter target)
    {
        //target.attackDamage = Mathf.RoundToInt(target.attackDamage * 1.1f);
        target.outgoingDamageModifiers.Add(damage => (int)(damage*1.1f));
    }

    public override void OnTimer(Fighter target)
    {
        target.TakeDamage(damagePerTurn);
    }




}
