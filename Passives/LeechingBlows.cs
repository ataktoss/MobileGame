using UnityEngine;

public class LeechingBlows : Passive, IEffect
{

    public float leechAmount = 0.3f;

    public LeechingBlows(float leechAmount):base("Leeching Blows","Heal for a % of damage done"){
        this.leechAmount = leechAmount;
    }
    public LeechingBlows(PassiveData data) : base(data)
    {
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        fighter.Heal(Mathf.RoundToInt(damage * leechAmount));
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
