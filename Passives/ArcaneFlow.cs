using UnityEngine;

public class ArcaneFlow : Passive, IEffect
{
    public ArcaneFlow(string name, string desc) : base(name, desc)
    {
    }

    public void Apply(Fighter caster, Fighter target)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplyEffect(Fighter fighter)
    {
        throw new System.NotImplementedException();
    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        fighter.ChangeMana(5);
    }

}
