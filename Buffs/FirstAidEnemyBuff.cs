using UnityEngine;

public class FirstAidEnemyBuff : StatusEffect
{
    public float healPerTurn;

    public FirstAidEnemyBuff(float healPerTurn, int duration, int howOften): base("FirstAidEnemyBuff",duration,howOften,StatusEffectType.Buff){
        this.healPerTurn = healPerTurn;
    }

    public override void OnApply(Fighter target)
    {
        Debug.Log(target.unitName + " Now has First Aid Buff");
    }

    public override void OnTimer(Fighter target)
    {
        
        Fighter lowestHPMonster = null;
        int lowestHP = int.MaxValue;
        foreach(var monster in CombatManager.Instance.GetMonsterList()){
            if(monster._currentLife < lowestHP){
                lowestHP = monster._currentLife;
                lowestHPMonster = monster;
            }
        }
        if(lowestHPMonster != null){
            lowestHPMonster.Heal(Mathf.RoundToInt(lowestHPMonster.TotalLife * healPerTurn));
        }
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }
    
}
