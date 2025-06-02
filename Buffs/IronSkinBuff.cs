using System;
using UnityEngine;

public class IronSkinBuff : StatusEffect
{

    int durationTimer = 2;
    Fighter targetOfBuff;
    Func<int, int> reduceDamage = (int damage) =>
        {
            // Reduce incoming damage by 20%
            int reducedDamage = Mathf.RoundToInt(damage * 0.8f);
            
            return reducedDamage;
        };
    public IronSkinBuff(int duration, int howOften) : base("IronSkinBuff", duration, howOften, StatusEffectType.Buff)
    {
    }

    public override void OnAPply(Fighter target)
    {
        
        target.damageModifiers.Add(reduceDamage);
    }
    public override void OnTimer(Fighter target)
    {
        durationTimer--;
        Debug.Log(target.unitName + " has Iron Skin Buff, " + durationTimer + " turns left");
        if (durationTimer <= 0)
        {
            OnExpire(target);
        }
    }
    public override void OnExpire(Fighter target)
    {
        target.damageModifiers.Remove(reduceDamage);
    }


}
