using UnityEngine;

public class BerserkersTempo : Passive, IEffect
{
    //Gain 20% attack speed every 3 seconds
    public BerserkersTempo(PassiveData data) : base(data)
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
        fighter.ApplyDebuff(new BerserkersTempoBuff(1.2f, 200, 3));
    }
    

}
