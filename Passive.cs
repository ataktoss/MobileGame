using UnityEngine;

public abstract class Passive
{

    public string passiveName;
    public string description;

    
    protected Passive(string name, string desc){
        passiveName = name;
        description = desc;
    }
    
    public abstract void ApplyEffect(Hero hero);


    public virtual void OnTakeDamage(Hero hero, int damage) {}
    public virtual void OnAttack(Hero hero, IFighter target, int damage) {}

    
}
