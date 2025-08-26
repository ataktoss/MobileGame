using UnityEngine;

public class ArcanePulse : Spell
{
    public ArcanePulse(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int baseDamage = 20 + Mathf.RoundToInt(spellPower * 0.5f);

        foreach (var enemy in CombatManager.Instance.GetMonsterList())
        {
            if (enemy == null || !enemy.isAlive)
            {
                continue; 
            }
            enemy.TakeDamage(baseDamage,caster);
        }
    }
}
