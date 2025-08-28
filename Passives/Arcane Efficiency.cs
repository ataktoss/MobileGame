using UnityEngine;

public class ArcaneEfficiency : Passive,IEffect
{
    //Passives cost 20% less
    public ArcaneEfficiency():base("Arcane Efficiency","Spells cost 20% less mana"){}

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        Debug.Log("Spells now cost 20% less mana");
        if(fighter.fighterSpell != null){
            fighter.fighterSpell.manaCost = Mathf.RoundToInt(fighter.fighterSpell.manaCost*0.8f);
        }

    }

}
