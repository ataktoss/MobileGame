using UnityEngine;

public class LeechingBlows : Passive, IEffect
{
    
    public float leechAmount;

    public LeechingBlows(float leechAmount):base("Leeching Blows","Heal for a % of damage done"){
        this.leechAmount = leechAmount;
    }



    public override void OnAttack(IFighter fighter, IFighter target, int damage)
    {
        fighter.Heal(Mathf.RoundToInt(damage*leechAmount));
    }

    public override void OnSpellCast(IFighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(IFighter fighter, int damage)
    {
        
    }


    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }
}
