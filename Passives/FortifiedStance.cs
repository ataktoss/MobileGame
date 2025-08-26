using UnityEngine;

public class FortifiedStance : Passive, IEffect
{
    public int leechAmount;
    private int hitsTakenCounter = 0;

    public FortifiedStance() : base("", "")
    {
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {
        hitsTakenCounter++;
        if (hitsTakenCounter >= 4)
        {
            fighter.Heal(damage); // Heal the fighter for the damage taken
            hitsTakenCounter = 0; // Reset the counter after healing
        }
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
