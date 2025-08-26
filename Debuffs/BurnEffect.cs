using UnityEngine;

public class BurnEffect : StatusEffect
{
    
    public int damagePerTurn;

    public BurnEffect(int damagePerTurn, int duration,int howOften): base("Burn",duration,howOften,StatusEffectType.Debuff){
        this.damagePerTurn = damagePerTurn;
    }

    public override void OnApply(Fighter target)
    {
        Debug.Log(target.unitName + " Is now burning");
    }

    public override void OnTimer(Fighter target)
    {
        target.TakeDamage(damagePerTurn);
        Debug.Log(target.name + " Took " + damagePerTurn + " from ignite");
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log(target.name + "Is no longer burning");
    }

}
