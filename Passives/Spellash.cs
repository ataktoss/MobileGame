using UnityEngine;

public class Spellash : Passive, IEffect
{
    //Attacks gain +30% of spellPower as bonus damage
    public Spellash(PassiveData data) : base(data)
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
    public override int ModifyDamageDone(Fighter fighter, Fighter target, int damage)
    {
        int bonusDamage = Mathf.RoundToInt(fighter.TotalSpellPower * 0.3f);
        return damage + bonusDamage;
    }

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
