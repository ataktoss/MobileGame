using UnityEngine;

public class ManaFlowBuff: StatusEffect
{
    public int manaPerTurn;

    public ManaFlowBuff(int manaPerTurn, int duration, int howOften): base("Cleanse",duration,howOften,StatusEffectType.Buff){
        this.manaPerTurn = manaPerTurn;
    }

    public override void OnApply(Fighter target)
    {
        Debug.Log(target.unitName + " Now has renew");
    }

    public override void OnTimer(Fighter target)
    {
        
        target.ChangeMana(manaPerTurn);
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }
}
