using UnityEngine;

public class ToxicPrecision : Passive, IEffect
{

    public ToxicPrecision(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        bool isCrit = UnityEngine.Random.value < fighter.TotalCriticalChance;
        if (isCrit)
        {
            target.ApplyDebuff(new PoisonEffect(Mathf.RoundToInt(fighter.TotalAttackDamage * 0.2f), 3, 1));
        }
        
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
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
