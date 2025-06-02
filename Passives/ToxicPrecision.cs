using UnityEngine;

public class ToxicPrecision : Passive, IEffect
{
    

    public ToxicPrecision():base("",""){
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        if(Random.value < fighter.critChance)
        {
            target.ApplyDebuff(new PoisonEffect(Mathf.RoundToInt(fighter.attackDamage * 0.2f), 4, 1));
        }
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
