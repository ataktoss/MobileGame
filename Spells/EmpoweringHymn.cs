using UnityEngine;

public class EmpoweringHymn : Spell
{

    public EmpoweringHymn(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {

        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            if (hero == null || !hero.isAlive) continue;

            hero.attackSpeed *= 0.9f;
            hero.attackDamage += 20;
            hero.spellPower += 30;
        }


    }
}
