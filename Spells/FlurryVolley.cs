using UnityEngine;

public class FlurryVolley : Spell
{
    public FlurryVolley(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int spellDamage = caster.attackDamage;
        foreach (var dmgBuff in caster.outgoingDamageModifiers)
        {
            spellDamage = dmgBuff(spellDamage);
        }
        foreach (var enemy in CombatManager.Instance.GetMonsterList())
        {
            if (enemy == null || !enemy.isAlive)
            {
                continue; // Skip if the enemy is null or dead
            }
            // Apply damage to all enemies except the target
            enemy.TakeDamage(spellDamage);
        }
    }

}
