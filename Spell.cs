using System.Collections.Generic;
using UnityEngine;

public class Spell
{

    public string name;
    public int manaCost;
    public int damage;

    public List<IEffect> additionalEffects = new List<IEffect>();

    public Spell(string name, int manaCost, int damage){
        this.name = name;
        this.manaCost = manaCost;
        this.damage = damage;
    }


    public virtual void ApplyEffect(IFighter caster,IFighter target,float spellPower){
        int finalDamage = (int)(damage*(1+spellPower));
        foreach(var weaken in target.outgoingDamageModifiers){
            finalDamage = weaken(finalDamage);
        }
        target.TakeDamage(finalDamage);
        Debug.Log(target.name + " Took " + damage + "Damage");

        foreach(var effect in additionalEffects){
            effect.Apply(caster,target);
        }
    }
}
