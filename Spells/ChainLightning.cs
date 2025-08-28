using UnityEngine;

public class ChainLightning : Spell
{
    public ChainLightning(string name,int manaCost,int damage) : base(name,manaCost,damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int baseDamage = Mathf.RoundToInt(10 + spellPower);
        foreach (var damageMod in caster.damageDoneModifiers)
        {
            baseDamage = damageMod(baseDamage);
        }
        foreach (var enemy in CombatManager.Instance.GetMonsterList())
        {
            if(enemy != null && enemy.isAlive)
            {
                enemy.TakeDamage(baseDamage, caster);
            }
        }
    }

    
}
