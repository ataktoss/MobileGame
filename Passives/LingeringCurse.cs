using System;
using UnityEngine;

public class LingeringCurse : Passive, IEffect
{

    public LingeringCurse(PassiveData data) : base(data)
    {

    }

    Func<int,int> ModifyDamage = (damage) => {
        return Mathf.RoundToInt(damage * 1.05f);
    };


    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        target.damageTakenModifiers.Add(ModifyDamage);
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

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
