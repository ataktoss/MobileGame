using UnityEngine;

public class FortifiedHeart : Passive, IEffect
{
    // If current health is above 50%, reduce damage taken by 15%
    public FortifiedHeart(PassiveData data) : base(data)
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
        float damageReduction = 0.15f;
        if(fighter._currentLife> fighter.TotalLife * 0.5f)
        {
            damage = Mathf.RoundToInt(damage * (1 - damageReduction));
        }

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
