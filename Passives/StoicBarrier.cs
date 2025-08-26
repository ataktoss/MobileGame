using System;
using UnityEngine;

public class StoicBarrier : Passive, IEffect
{
    Func<int, int> damageReduction = (damage) => Mathf.RoundToInt(damage * 0.9f);
    public StoicBarrier(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }
    public override void OnCrit(Fighter fighter,Fighter target,int damage,bool isCritical)
    {
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        return damage; 
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {
        if (fighter._currentLife < Mathf.RoundToInt(fighter.TotalLife * 0.7f))
        {
            foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero.isAlive && hero != null){
                hero.damageTakenModifiers.Remove(damageReduction);
            }
        }
        }
    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero.isAlive && hero != null){
                hero.damageTakenModifiers.Add(damageReduction);
            }
        }
    }
    

}
