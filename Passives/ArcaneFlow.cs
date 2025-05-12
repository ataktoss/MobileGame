using UnityEngine;

public class ArcaneFlow : Passive, IEffect
{
    public ArcaneFlow(string name, string desc) : base(name, desc)
    {
    }

    public void Apply(IFighter caster, IFighter target)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplyEffect(IFighter fighter)
    {
        throw new System.NotImplementedException();
    }

    public override void OnAttack(IFighter fighter, IFighter target, int damage)
    {
        fighter.ChangeMana(5);
    }

}
