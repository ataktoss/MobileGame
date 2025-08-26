using UnityEngine;

public class PredatorsFrenzy : Spell
{
    public PredatorsFrenzy(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
        // Initialize the spell with the provided data
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        float bonusCritDamage = 0.4f;
        caster.critDamage += bonusCritDamage;
        caster.ApplyDebuff(new LifestealBuff(0.1f, 200, 3)); // Apply lifesteal buff for 30% leech amount
        

    }
    
    

}

