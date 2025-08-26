using UnityEngine;

public class SecondWind : Passive, IEffect
{
    public SecondWind(PassiveData data) : base(data)
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
        fighter.ApplyDebuff(new RenewBuff(Mathf.RoundToInt(fighter.life * 0.1f), 200, 3));
    }
}
