using UnityEngine;

public class CleanseBuff:StatusEffect
{
    public int healPerTurn;

    public CleanseBuff(int healPerTurn, int duration, int howOften): base("Cleanse",duration,howOften,StatusEffectType.Buff){
        this.healPerTurn = healPerTurn;
    }

    public override void OnApply(Fighter target)
    {
        Debug.Log(target.unitName + " Now has renew");
    }

    public override void OnTimer(Fighter target)
    {
        for(int i = target.activeEffects.Count -1; i>=0; i--){
            if(target.activeEffects[i].effectType == StatusEffect.StatusEffectType.Debuff){
                target.activeEffects[i].OnExpire(target)                ;
                target.activeEffects.RemoveAt(i);
                Debug.Log("Just removed a debuff");
                break;
            }
        }
    }

    public override void OnExpire(Fighter target)
    {
        Debug.Log(target.name + " no longer has renew");
    }
}
