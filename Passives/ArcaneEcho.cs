using UnityEngine;

public class ArcaneEcho : Passive
{
    public ArcaneEcho() : base("Arcane Echo", "Deal extra damage on hit based on Spell Power")
    {
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }
    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        int extraDamage = Mathf.RoundToInt(fighter.spellPower * 0.3f) + 10; // Base extra damage is 10 plus 30% of spell power
        foreach (var dmgBonus in fighter.damageDoneModifiers)
        {
            extraDamage = dmgBonus(extraDamage);
        }
        target.TakeDamage(extraDamage,fighter);
    }
    
    public override void ApplyEffect(Fighter fighter)
    {
        // No additional effect to apply
    }

}
