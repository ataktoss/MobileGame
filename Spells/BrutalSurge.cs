using UnityEngine;

public class BrutalSurge : Spell
{
    public BrutalSurge(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int bonusAttackDamage = 15;
        caster.attackDamage += bonusAttackDamage; 
    }
}
