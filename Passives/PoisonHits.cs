using UnityEngine;

public class PoisonHits : Passive, IEffect
{
    
    public int poisonDamage;

    public PoisonHits(int poisonDamage):base("Poison Hits","On hit poison the enemy"){
        this.poisonDamage = poisonDamage;
    }

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        int theDamage = fighter.attackDamage;
        target.ApplyDebuff(new PoisonEffect(theDamage,2,1));
    }

}
