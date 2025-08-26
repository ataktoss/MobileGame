using UnityEngine;

public class SerratedStrikes : Passive, IEffect
{

    public SerratedStrikes(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        float chanceToBleed = fighter.critChance;
        if(Random.value <= chanceToBleed)
        {
            int bleedDamage = Mathf.RoundToInt(fighter.TotalAttackDamage * 0.2f);
            target.ApplyDebuff(new BleedEffect(bleedDamage, 3, 1));
            
        }
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

    }
    

}
