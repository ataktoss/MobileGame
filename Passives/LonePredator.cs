using System;
using UnityEngine;

public class LonePredator : Passive, IEffect
{
    

    public LonePredator(PassiveData data):base(data){
        
    }


    private Func<int, int> currentModifier = null;
    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

        bool isTargeted = target.currentTarget == fighter; // true

        if (currentModifier != null)
        {
            fighter.damageDoneModifiers.Remove(currentModifier);
            currentModifier = null;
        }
        if (isTargeted)
        {
            currentModifier = dmg => Mathf.RoundToInt(dmg * 0.8f);
        }
        else if(!isTargeted)
        {
            currentModifier = dmg => Mathf.RoundToInt(dmg * 1.2f);
        }
        fighter.damageDoneModifiers.Add(currentModifier);
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {
        
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
