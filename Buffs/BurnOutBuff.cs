using UnityEngine;

public class BurnOutBuff : StatusEffect
{
    //Increase damage of next attack by damageIncrease%
    public float damageIncrease;
    public BurnOutBuff(float damageIncrease, int duration, int howOften): base("BurnOut",duration,howOften,StatusEffectType.Buff){
        this.damageIncrease = damageIncrease;   
    }

    public override void OnApply(Fighter target)
    {
        target.attackDamage = Mathf.RoundToInt(target.attackDamage * damageIncrease);
    }

    public override void OnTimer(Fighter target)
    {
        
    }

    public override void OnExpire(Fighter target)
    {
        target.attackDamage = Mathf.RoundToInt(target.attackDamage * 0.6f);
    }
}
