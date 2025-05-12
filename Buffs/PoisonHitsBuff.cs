using UnityEngine;

public class PoisonHitsBuff : StatusEffect
{
    public int poisonDamage;

    public PoisonHitsBuff(int poisonDamage,int duration,int howOften):base("PoisonHits",duration,howOften,StatusEffectType.Buff){
        this.poisonDamage = poisonDamage;
    }

    



}
