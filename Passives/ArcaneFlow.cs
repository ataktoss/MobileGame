using UnityEngine;

public class ArcaneFlow : Passive, IEffect
{
    public ArcaneFlow() : base("Arcane Flow", "Increases mana regeneration.")
    {
    }

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        fighter.ChangeMana(5);
    }

}
