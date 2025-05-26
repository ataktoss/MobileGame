using UnityEngine;

public class PoisonEffect : StatusEffect
{
    public int damagePerTurn;

    public PoisonEffect(int damagePerTurn, int duration,int howOften): base("Poison",duration,howOften,StatusEffectType.Debuff){
        this.damagePerTurn = damagePerTurn;
    }

    public override void OnAPply(Fighter target)
    {
        //Debug.Log(target.unitName + " Now is poisoned");
    }

    public override void OnTimer(Fighter target)
    {
        if (target != null)
        {
            target.TakeDamage(damagePerTurn);    
        }
        
        //Debug.Log(target.name + " Took " + damagePerTurn + " from poison");
    }

    public override void OnExpire(Fighter target)
    {
        //Debug.Log(target.name + "Is no longer poisoned");
    }
}
