using System;
using UnityEngine;

public class WeakenEffect : StatusEffect
{
    public float weakenAmount;
    private Func<int, int> damageModifier;

    public WeakenEffect(float weakenAmount,int duration,int howOften): base("Weaken",duration,howOften,StatusEffectType.Debuff){
        this.weakenAmount = weakenAmount;
    }

    public override void OnAPply(IFighter target)
    {
        
        damageModifier = (damage) => Mathf.CeilToInt(damage*weakenAmount);
        target.damageModifiers.Add(damageModifier);
        Debug.Log($"{target.unitName} is Weakened! and now deals " + weakenAmount + " less damage ");


        
        Debug.Log(target.unitName + " Is now Cursed");
        
    }

    public override void OnTimer(IFighter target)
    {
        
    }

    public override void OnExpire(IFighter target)
    {
        if(target){
            target.damageModifiers.Remove(damageModifier);
            Debug.Log(target.name + "Is no longer burning");
        }
        
    }
}
