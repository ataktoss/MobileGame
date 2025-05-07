using UnityEngine;

public class BurnOutBuff : StatusEffect
{
    
    public float damageIncrease;
    public BurnOutBuff(int damageIncrease, int duration, int howOften): base("BurnOut",duration,howOften,StatusEffectType.Buff){
        this.damageIncrease = damageIncrease;   
    }

    public override void OnAPply(IFighter target)
    {
        target.attackDamage = Mathf.RoundToInt(target.attackDamage * 1.4f);
    }

    public override void OnTimer(IFighter target)
    {
        
    }

    public override void OnExpire(IFighter target)
    {
        target.attackDamage = Mathf.RoundToInt(target.attackDamage * 0.6f);
    }
}
