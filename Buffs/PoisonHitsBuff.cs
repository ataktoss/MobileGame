using UnityEngine;

public class PoisonHitsBuff : StatusEffect
{
    public int poisonChance;

    public PoisonHitsBuff(int poisonChance,int duration,int howOften):base("PoisonHits",duration,howOften,StatusEffectType.Buff){
        this.poisonChance = poisonChance;
    }

    public override void OnAttack(Fighter attacker, int damage)
    {
        if(Random.Range(0, 100) < poisonChance)
        {
            if(attacker.currentTarget != null && attacker.currentTarget.isAlive)
            {
                int poisonDamage = Mathf.RoundToInt(attacker.TotalAttackDamage * 0.2f);
                attacker.currentTarget.ApplyDebuff(new PoisonEffect(poisonDamage, 3,1)); 
                
            }
        }
    }

}
