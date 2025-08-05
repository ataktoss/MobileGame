using System;
using UnityEngine;

public class IronRythmBuff : StatusEffect
{
    int durationTimer = 2;
    Fighter targetOfBuff;
    Func<int, int> ironRythmMod = (int damage) =>
        {
            // Reduce incoming damage by 20%
            int reducedDamage = Mathf.RoundToInt(damage * 0.8f);
            
            return reducedDamage;
        };
    public IronRythmBuff(int duration, int howOften) : base("IronRythmBuff", duration, howOften, StatusEffectType.Buff)
    {
    }

    public override void OnApply(Fighter target)
    {
        
        target.damageTakenModifiers.Add(ironRythmMod);
    }
    public override void OnTimer(Fighter target)
    {
        durationTimer--;
        Debug.Log(target.unitName + " has Iron Rythm Buff, " + durationTimer + " turns left");
        if (durationTimer <= 0)
        {
            OnExpire(target);
        }
    }
    public override void OnExpire(Fighter target)
    {
        target.damageTakenModifiers.Remove(ironRythmMod);
    }
}
