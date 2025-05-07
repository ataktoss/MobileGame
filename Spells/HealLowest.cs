using System.Collections.Generic;
using UnityEngine;

public class HealLowest: Spell
{
    public HealLowest(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
        
    }


    public override void ApplyEffect(IFighter caster,IFighter target,float spellPower){
        List<IFighter> heroes =  CombatManager.Instance.GetHeroList();
        IFighter lowestHealthHero = null;
        int minHealth = int.MaxValue;

        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero == null || !hero.isAlive) continue;
            if(hero._currentLife < minHealth){
                minHealth = hero._currentLife;
                lowestHealthHero = hero;
            }
        }
        if(lowestHealthHero != null){
            lowestHealthHero.Heal(damage + Mathf.RoundToInt(1*spellPower));
        }


    }

    

}
