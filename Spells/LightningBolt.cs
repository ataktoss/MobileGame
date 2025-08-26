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

        int spellDamage = Mathf.RoundToInt(30 + spellPower * 0.4f);
        foreach(var damageMod in caster.damageDoneModifiers)
        {
            spellDamage = damageMod(spellDamage);
        }
        target.TakeDamage(spellDamage,caster);
    }
}
