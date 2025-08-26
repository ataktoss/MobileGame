using UnityEngine;

public class BloodFrenzy : Passive, IEffect
{
    //On crit gain 10% attack speed

    public BloodFrenzy(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }
    public override void OnCrit(Fighter fighter, Fighter target, int damage, bool isCritical)
    {
        float bonusAttackSpeed = 0.9f; // 10% increase
        if (isCritical)
        {
            fighter.attackSpeed *= bonusAttackSpeed;
        }
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

    }
    

}
