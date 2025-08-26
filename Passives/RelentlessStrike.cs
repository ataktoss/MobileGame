using System;
using UnityEngine;

public class RelentlessStrikePassive : Passive, IEffect
{
    

    public RelentlessStrikePassive():base("",""){

    }

    Func<int,int> damageBonus = (int d) =>
    {
        int bonusDamage = Mathf.RoundToInt(d * 0.5f);
        Debug.Log($"Relentless Strike bonus damage: {bonusDamage}");
        return d + bonusDamage;
    };

    int currentNumberAttack;
    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        if (currentNumberAttack ==1)
        {
            fighter.damageDoneModifiers.Add(damageBonus);
            
        }
        if(currentNumberAttack > 1)
        {
            fighter.damageDoneModifiers.Remove(damageBonus);
            Debug.Log("Relentless Strike bonus damage removed");
            //fighter.RemovePassive(this);
            
        }
        

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        currentNumberAttack = 0;
    }

    


    public void Apply(Fighter caster, Fighter target)
    {
        currentNumberAttack = 0;
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
