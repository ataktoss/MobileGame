using UnityEngine;

public class RunicPulse : Passive, IEffect
{
    

    public RunicPulse():base("",""){
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        fighter.CastSpell(fighter.fighterSpell, target);

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
