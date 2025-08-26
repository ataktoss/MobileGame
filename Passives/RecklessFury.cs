using System;
using UnityEngine;

public class RecklessFury : Passive, IEffect
{

    //Deal 15% more damage but take 15% more damage
    Func<int,int> modifyDamageDone = (damage) => (int)(damage * 1.15f);
    Func<int,int> modifyDamageTaken = (damage) => (int)(damage * 1.15f);
    public RecklessFury(PassiveData data) : base(data)
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

    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {
        fighter.damageDoneModifiers.Add(modifyDamageDone);
        fighter.damageTakenModifiers.Add(modifyDamageTaken);
    }
    

}
