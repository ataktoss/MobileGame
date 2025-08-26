using UnityEngine;

public class OpeningGambit : Passive, IEffect
{
    //First hit of combat does 3 times as much damage
    int numberOfHits = 0;
    public OpeningGambit(PassiveData data) : base(data)
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
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        if (numberOfHits == 0)
        {
            numberOfHits++;
            return damage * 3; // Triple damage for the first hit
        }
        return damage; 
    }

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
