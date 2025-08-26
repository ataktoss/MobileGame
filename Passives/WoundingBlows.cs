using UnityEngine;

public class WoundingBlows : Passive, IEffect
{
    //On crit apply 10% damage taken debuff on enemy
    public WoundingBlows(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        return damage; 
    }

    public override void OnCrit(Fighter fighter,Fighter target,int damage, bool isCritical) 
    {
        if(isCritical)
        {
            target.ApplyDebuff(new VulnerableEffect(200, 1, 0.9f));
        }
    }
    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
