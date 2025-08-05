using UnityEngine;

public class FirstAidBuff : StatusEffect
{
    public int healPerTurn;

    public FirstAidBuff(int healPerTurn, int duration, int howOften): base("FirstAidBuff",duration,howOften,StatusEffectType.Buff){
        this.healPerTurn = healPerTurn;
    }

    public override void OnApply(Fighter target)
    {
        Debug.Log(target.unitName + " Now has First Aid Buff");
    }

    public override void OnTimer(Fighter target)
    {
        
        Fighter lowestHPHero = null;
        int lowestHP = int.MaxValue;
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero._currentLife < lowestHP){
                lowestHP = hero._currentLife;
                lowestHPHero = hero;
            }
        }
        if(lowestHPHero != null){
            lowestHPHero.Heal(Mathf.RoundToInt(lowestHPHero.life * 0.05f));
        }
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }
    
}
