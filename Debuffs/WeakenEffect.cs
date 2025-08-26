using System;
using UnityEngine;

public class WeakenEffect : StatusEffect
{
    public float weakenAmount;
    private Func<int, int> damageModifier;

    public WeakenEffect(float weakenAmount,int duration,int howOften): base("Weaken",duration,howOften,StatusEffectType.Debuff){
        this.weakenAmount = weakenAmount;
    }

    public override void OnApply(Fighter target)
    {
        
        damageModifier = (damage) => Mathf.CeilToInt(damage*weakenAmount);
        target.damageTakenModifiers.Add(damageModifier);
        Debug.Log($"{target.unitName} is Weakened! and now deals " + weakenAmount + " less damage ");


        
        Debug.Log(target.unitName + " Is now Cursed");
        
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
