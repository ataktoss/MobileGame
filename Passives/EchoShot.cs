using UnityEngine;

public class EchoShot : Passive, IEffect
{
    

    public EchoShot():base("",""){
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        if (Random.value < 0.05f)
        {
            fighter.Attack(target, damage);

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
