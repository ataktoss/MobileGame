using System;
using UnityEngine;

public class CurseEffect : StatusEffect
{

    public float curseAmount;
    private Func<int, int> damageModifier;

    public CurseEffect(float curseAmount,int duration,int howOften): base("Curse",duration,howOften,StatusEffectType.Debuff){
        this.curseAmount = curseAmount;
    }

    public override void OnAPply(Fighter target)
    {
        
        damageModifier = (damage) => Mathf.CeilToInt(damage*curseAmount);
        target.damageTakenModifiers.Add(damageModifier);
        Debug.Log($"{target.unitName} is cursed! and now takes " + curseAmount + " more damage ");


        
        Debug.Log(target.unitName + " Is now Cursed");
        
    }

    public override void OnTimer(Fighter target)
    {
        
    }

    public override void OnExpire(Fighter target)
    {
        if(target){
            target.damageTakenModifiers.Remove(damageModifier);
            Debug.Log(target.name + "Is no longer Cursed");
        }
        
    }
}
