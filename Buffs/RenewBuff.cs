using UnityEngine;

public class RenewBuff : StatusEffect
{

    public int healPerTurn;

    public RenewBuff(int healPerTurn, int duration, int howOften): base("Renew",duration,howOften){
        this.healPerTurn = healPerTurn;
    }

    public override void OnAPply(IFighter target)
    {
        Debug.Log(target.unitName + " Now has renew");
    }

    public override void OnTimer(IFighter target)
    {
        target.Heal(healPerTurn);
        Debug.Log(target.name + " healed for : " + healPerTurn + " from renew");
    }

    public override void OnExpire(IFighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }


    
}
