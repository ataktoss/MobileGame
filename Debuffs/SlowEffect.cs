using UnityEngine;

public class SlowEffect : StatusEffect
{
    
    //public int damagePerTurn;
    public float savedSpeed;
    public float slowAmount;

    public SlowEffect(int damagePerTurn, int duration,int howOften): base("Poison",duration,howOften,StatusEffectType.Debuff){
        //this.damagePerTurn = damagePerTurn;
    }

    public override void OnApply(Fighter target)
    {
        savedSpeed = target.attackSpeed;
        target.attackSpeed  *= 2f;
    }

    public override void OnTimer(Fighter target)
    {
        // target.TakeDamage(damagePerTurn);
        //Debug.Log(target.name + " Took " + damagePerTurn + " from poison");
    }

    public override void OnExpire(Fighter target)
    {
        if(target){
            target.attackSpeed = savedSpeed;
            Debug.Log(target.name + "Is no longer slowed");
        }
        
    }
}
