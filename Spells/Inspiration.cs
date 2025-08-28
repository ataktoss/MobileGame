using System;
using UnityEngine;

public class Inspiration : Spell
{
    public Inspiration(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    
    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        float damageMultiplier = 1.2f + (0.01f * (spellPower * 0.5f));
        Func<int, int> modifyDamageDone = (damage) => Mathf.RoundToInt(damage * damageMultiplier);

        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            if (hero == null || !hero.isAlive) continue;
            if (hero)
            {
                hero.damageDoneModifiers.Add(modifyDamageDone);
            }
        }


    }
}
