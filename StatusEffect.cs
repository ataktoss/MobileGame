using UnityEngine;

public abstract class StatusEffect
{
    public string effectName;
    public int duration;

    protected StatusEffect(string name, int duration){
        this.effectName = name;
        this.duration = duration;
    }


    public virtual void OnAPply(IFighter target){}
    public virtual void OnTimer(IFighter target){}
    public virtual void OnExpire(IFighter target){}

}
