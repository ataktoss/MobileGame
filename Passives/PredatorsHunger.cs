using UnityEngine;

public class PredatorsHunger : Passive, IEffect
{
    //If target is above 70% health deal 30% more damage
    public PredatorsHunger(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }
    public override void OnCrit(Fighter fighter,Fighter target,int damage,bool isCritical)
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
        int lifeThreshold = Mathf.RoundToInt(target.TotalLife * 0.7f);
        if (target._currentLife > lifeThreshold)
        {
            return Mathf.RoundToInt(damage * 1.3f);
        }
        
        return damage; 
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {

    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
