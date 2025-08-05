using UnityEngine;

public class GuardiansAegis : Spell
{
    //Shield caster for 20% of their total life
    public GuardiansAegis(string name, int manaCost, int damage) : base(name, manaCost, damage) { }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        caster.ChangeShield(Mathf.RoundToInt(caster.TotalLife * 0.2f)); 
    }
}
    

