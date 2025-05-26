using UnityEngine;

public class BrutalSwing : Spell
{
    public BrutalSwing(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster,Fighter target,float spellPower){
        int currentAttackPower = caster.attackDamage;
        int finalDamage = (int)(currentAttackPower*2);
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
