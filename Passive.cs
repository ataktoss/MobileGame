using UnityEngine;

[System.Serializable    ]
public abstract class Passive
{

    public string passiveName;
    public string description;


    protected Passive(string name, string desc)
    {
        passiveName = name;
        description = desc;
    }

    //Use to apply permanent buffs/debuffs ktlp Should trigger once per fight
    public abstract void ApplyEffect(Fighter fighter);


    public virtual void OnTakeDamage(Fighter fighter, int damage) { }
    public virtual void OnAttack(Fighter fighter, Fighter target, int damage) { }

    public virtual void OnSpellCast(Fighter fighter, int manaCost) { }
    public virtual void OnDeath(Fighter fighter) { }
}
