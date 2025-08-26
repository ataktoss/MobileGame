using UnityEngine;

public class BloodPact : Spell
{
    //Sacrifice 10% of hp to gain 20% bonus attack damage
    public BloodPact(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        
        int sacrificeAmount = Mathf.FloorToInt(caster.TotalLife * 0.1f);
        caster._currentLife -= sacrificeAmount;
        int additionalDamage = Mathf.FloorToInt(caster.attackDamage * 0.2f);
        caster.attackDamage += additionalDamage;
    }
}

