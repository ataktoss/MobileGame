using UnityEngine;

public class ArcaneEfficiency : Passive,IEffect
{

    public ArcaneEfficiency():base("Arcane Efficiency","Spells cost 20% less mana"){}

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        Debug.Log("Spells now cost 20% less mana");
        if(fighter.fighterSpell != null){
            fighter.fighterSpell.manaCost = Mathf.RoundToInt(fighter.fighterSpell.manaCost*0.8f);
        }

    }

}
