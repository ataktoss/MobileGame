using System;
using UnityEngine;

public class WeakenEffect : StatusEffect
{
    //Enemy does % less damage 
    public float weakenAmount;
    private Func<int, int> damageModifier;

    public WeakenEffect(float weakenAmount,int duration,int howOften): base("Weaken",duration,howOften,StatusEffectType.Debuff){
        this.weakenAmount = weakenAmount;
    }

    public override void OnApply(Fighter target)
    {
        
        damageModifier = (damage) => Mathf.CeilToInt(damage*weakenAmount);
        target.damageDoneModifiers.Add(damageModifier);
        Debug.Log($"{target.unitName} is Weakened! and now does " + weakenAmount + " less damage ");


        
        
        
    }

    public override void OnTimer(Fighter target)
    {
        
    }

    public override void OnExpire(Fighter target)
    {
        if(target){
            target.damageTakenModifiers.Remove(damageModifier);
            Debug.Log(target.name + "Is no longer burning");
        }
        
    }
}
