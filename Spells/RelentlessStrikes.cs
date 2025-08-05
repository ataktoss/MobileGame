using System.Linq;
using UnityEngine;

public class RelentlessStrikes : Spell
{

    public RelentlessStrikes(string name,int manacost, int damage) : base(name, manacost, damage)
    {
        
    }
    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        
        bool hasrelentlessStrike = caster.passives.Any(p => p is RelentlessStrikePassive);
        if (hasrelentlessStrike)
        {
            //Play animation here
        }
        else
        {
            caster.AddPassive(new RelentlessStrikePassive());
        }
        //Do cast animation here
        
    }
}
