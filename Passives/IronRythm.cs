using System;
using UnityEngine;

public class IronRhythm : Passive, IEffect
{
    //On hit get 20% damage reduction for 2 seconds
    
    public IronRhythm(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        int buffDuration = 2;
        fighter.ApplyDebuff(new IronRythmBuff(buffDuration, 1));
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter, Fighter target, int damage)
    {
        return damage; 
    }

    public override void OnTakeDamage(Fighter fighter, int damage)
    {

    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
