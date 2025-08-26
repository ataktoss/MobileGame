using UnityEngine;

public class ArcanizedSteel : Passive, IEffect
{

    public ArcanizedSteel(PassiveData data) : base(data)
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
        damage += bonusDamage;
        return damage;
    }

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
