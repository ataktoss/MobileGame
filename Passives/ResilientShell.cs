using UnityEngine;

public class ResilientShell : Passive, IEffect
{
    private int currentAmountOfHitsTaken = 0;
    public ResilientShell(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    //Block every 4th hit
    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        currentAmountOfHitsTaken++;
        if (currentAmountOfHitsTaken >= 4)
        {
            return 0;
        }
        else
        {
            return damage;
        }


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
