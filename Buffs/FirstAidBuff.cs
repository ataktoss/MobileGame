using UnityEngine;

public class FirstAidBuff : StatusEffect
{
    public int healPerTurn;

    public FirstAidBuff(int healPerTurn, int duration, int howOften): base("Cleanse",duration,howOften,StatusEffectType.Buff){
        this.healPerTurn = healPerTurn;
    }

    public override void OnAPply(IFighter target)
    {
        Debug.Log(target.unitName + " Now has renew");
    }

    public override void OnTimer(IFighter target)
    {
        
        IFighter lowestHPHero = null;
        int lowestHP = int.MaxValue;
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero._currentLife < lowestHP){
                lowestHP = hero._currentLife;
                lowestHPHero = hero;
            }
        }
        if(lowestHPHero != null){
            lowestHPHero.Heal(healPerTurn);
        }
    }

    public override void OnExpire(IFighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }
    
}
