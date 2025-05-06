using UnityEngine;

public abstract class StatusEffect
{
    public string effectName;
    public int duration;
    public int howOften;

    private float lastTickTime = 0f;    

    protected StatusEffect(string name, int duration,int howOften){
        this.effectName = name;
        this.duration = duration;
        this.howOften = howOften;
    }

    public void TryTick(IFighter target){
        if(Time.time>= lastTickTime + howOften){
            OnTimer(target);
            duration--;
            lastTickTime = Time.time;
        }
    }



    public virtual void OnAPply(IFighter target){}
    public virtual void OnTimer(IFighter target){}
    public virtual void OnExpire(IFighter target){}

}
