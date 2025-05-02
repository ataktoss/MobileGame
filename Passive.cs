using UnityEngine;

public abstract class Passive
{

    public string passiveName;
    public string description;

    
    protected Passive(string name, string desc){
        passiveName = name;
        description = desc;
    }
    
    public abstract void ApplyEffect(IFighter fighter);


    public virtual void OnTakeDamage(IFighter fighter, int damage) {}
    public virtual void OnAttack(IFighter fighter, IFighter target, int damage) {}

    
}
