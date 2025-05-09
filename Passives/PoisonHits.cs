using UnityEngine;

public class PoisonHits : Passive, IEffect
{
    
    public int poisonDamage;

    public PoisonHits(int poisonDamage):base("Poison Hits","On hit poison the enemy"){
        this.poisonDamage = poisonDamage;
    }

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }

    public override void OnAttack(IFighter fighter, IFighter target, int damage)
    {
        target.ApplyDebuff(new PoisonEffect(poisonDamage,2,1));
    }

}
