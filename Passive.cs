using UnityEngine;

public abstract class Passive
{

    public string passiveName;
    public string description;

    
    protected Passive(string name, string desc){
        passiveName = name;
        description = desc;
    }
    
    //Use to apply permanent buffs/debuffs ktlp Should trigger once per fight
    public abstract void ApplyEffect(IFighter fighter);


    public virtual void OnTakeDamage(IFighter fighter, int damage) {}
    public virtual void OnAttack(IFighter fighter, IFighter target, int damage) {}

    public virtual void OnSpellCast(IFighter fighter, int manaCost){}
    public virtual void OnDeath(IFighter fighter){}
}
