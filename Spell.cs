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


    public void ApplyEffect(IFighter caster,IFighter target){
        target.TakeDamage(damage);
        Debug.Log(target.name + " Took " + damage + "Damage");

        foreach(var effect in additionalEffects){
            effect.Apply(caster,target);
        }


    }





    
}
