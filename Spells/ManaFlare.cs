using UnityEngine;

public class ManaFlare : Spell
{
    public ManaFlare(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int baseSpellDamage = 30;
        int finalDamage = baseSpellDamage + Mathf.RoundToInt(spellPower * 0.6f);
        foreach (var dmgBuff in caster.outgoingDamageModifiers)
        {
            finalDamage = dmgBuff(finalDamage);
        }
        foreach (var enemy in CombatManager.Instance.GetMonsterList())
        {
            if (enemy == null || !enemy.isAlive)
            {
                continue; // Skip if the enemy is null or dead
            }
            // Apply damage to all enemies except the target
            enemy.TakeDamage(finalDamage);
        }
        
    }

}
