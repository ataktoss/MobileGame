using System;
using UnityEngine;

public abstract class StatusEffect
{
    public string effectName;
    public int duration;
    public int howOften;
    public enum StatusEffectType{
        Buff,Debuff,Neutral
    }
    public StatusEffectType effectType;
    
    private float lastTickTime = 0f;    

    protected StatusEffect(string name, int duration,int howOften,StatusEffectType type){
        this.effectName = name;
        this.duration = duration;
        this.howOften = howOften;
        this.effectType = type;
    }

    public void TryTick(Fighter target){
        if(Time.time>= lastTickTime + howOften){
            OnTimer(target);
            duration--;
            lastTickTime = Time.time;
        }
    }


    //On apply should trigger once by meaning on application of the buff/debuff
    public virtual void OnAPply(Fighter target){}
    public virtual void OnTimer(Fighter target){}
    public virtual void OnExpire(Fighter target){}

    
}
