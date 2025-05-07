using UnityEngine;

public class SpellEcho : Passive
{
    
    public SpellEcho():base("Spell Echo","After a few seconds recast your spell for free"){}

    public override void ApplyEffect(IFighter fighter)
    {
        throw new System.NotImplementedException();
    }

    public override void OnSpellCast(IFighter fighter, int manaCost)
    {
        
    }
}
