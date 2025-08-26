using UnityEngine;

public class VenomChoir : Spell
{
    public VenomChoir(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            hero.ApplyDebuff(new PoisonHitsBuff(100, 200, 1));
        }
    }
}

