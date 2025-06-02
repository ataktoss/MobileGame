using UnityEngine;

public class SilentEdge : Spell
{
    public SilentEdge(string name, int manaCost, int cooldown) : base(name, manaCost, cooldown)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        caster.critChance += 0.05f; 
    }
}
