using UnityEngine;

public class Opportunist : Passive, IEffect
{
   

    public Opportunist():base("",""){
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        if(target.currentTarget != fighter)
        {
            target.TakeDamage(Mathf.RoundToInt(damage * 0.2f),fighter);
        }
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {
        
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
