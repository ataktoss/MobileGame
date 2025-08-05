using UnityEngine;

public class LightningBolt : Spell
{
    public LightningBolt(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        if (target == null || !target.isAlive)
        {
            return; // Do nothing if the target is null or dead
        }

        int spellDamage = Mathf.RoundToInt(20 + spellPower * 0.4f);
        target.TakeDamage(spellDamage);
    }
}
