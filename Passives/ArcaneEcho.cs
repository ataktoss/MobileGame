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
        foreach (var dmgBonus in fighter.outgoingDamageModifiers)
        {
            extraDamage = dmgBonus(extraDamage);
        }
        target.TakeDamage(extraDamage);
    }
    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        // No effect on taking damage
    }
    public override void ApplyEffect(Fighter fighter)
    {
        // No additional effect to apply
    }

}
