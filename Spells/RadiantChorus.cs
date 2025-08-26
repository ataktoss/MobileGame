using System.Collections.Generic;
using UnityEngine;

public class RadiantChorus : Spell
{
    public RadiantChorus(string name, int manaCost, int cooldown) : base(name, manaCost, cooldown)
    {
        
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        List<Fighter> heroes = CombatManager.Instance.GetHeroList();
        foreach (Fighter hero in heroes)
        {
            if (hero != null)
            {
                int healAmount = Mathf.RoundToInt(hero.TotalLife * 0.1f); // Heal 10% of total life
                float attackSpeedIncrease = 1.3f;
                hero.Heal(healAmount);
                hero.attackSpeed /= attackSpeedIncrease;
            }
        }
    }
}

