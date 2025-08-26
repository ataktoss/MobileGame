using UnityEngine;

public class BladeStormFlurry : Spell
{
    public BladeStormFlurry(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        foreach (var enemy in CombatManager.Instance.GetMonsterList())
        {
            if (enemy == null || !enemy.isAlive)
            {
                continue; // Skip if the enemy is null or dead
            }
            caster.Attack(enemy, caster.TotalAttackDamage);
            
        }
    }
}
