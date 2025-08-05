using UnityEngine;

public class SpellWeaverSpell : Spell
{
    public SpellWeaverSpell(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int spellDamage = 5 + Mathf.RoundToInt(spellPower * 0.2f);
        if (target == null || !target.isAlive)
        {
            return;
        }
        target.TakeDamage(spellDamage);
    }
}
