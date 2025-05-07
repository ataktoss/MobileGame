using UnityEngine;

public class ChaosSurge : Passive,IEffect
{
    public ChaosSurge():base("Chaos Surge","+10% chance to cast spell twice"){}


    public override void OnSpellCast(IFighter fighter, int manaCost)
    {
        
        if (Random.value < 0.10f) // 10% chance
        {
            fighter.fighterSpell.ApplyEffect(fighter,fighter.currentTarget,fighter.spellPower);
        }
    }
    
    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }
}
