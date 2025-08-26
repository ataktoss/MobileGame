using UnityEngine;

public class VitalWrath : Passive, IEffect
{

    //Gain bonus attack damage equal to 10% of total life
    public VitalWrath(PassiveData data) : base(data)
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

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {
        int bonusDamage = Mathf.RoundToInt(fighter.TotalLife * 0.1f);
        fighter.attackDamage += bonusDamage;
    }
    

}
