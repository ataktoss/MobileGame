using UnityEngine;

public class RenewBuff : StatusEffect
{

    public int healPerTurn;

    public RenewBuff(int healPerTurn, int duration, int howOften): base("Renew",duration,howOften,StatusEffectType.Buff){
        this.healPerTurn = healPerTurn;
    }

    public override void OnAPply(Fighter target)
    {
        Debug.Log(target.unitName + " Now has renew");
    }

    public override void OnTimer(Fighter target)
    {
        target.Heal(healPerTurn);
        Debug.Log(target.name + " healed for : " + healPerTurn + " from renew");
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }


    
}
