using UnityEngine;

public class BrutalSwing : Spell
{
    public BrutalSwing(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster,Fighter target,float spellPower){
        int currentAttackPower = caster.TotalAttackDamage;
        int finalDamage = (int)(currentAttackPower*2);
        foreach(var weaken in caster.damageDoneModifiers){
            finalDamage = weaken(finalDamage);
        }
        //target.TakeDamage(finalDamage);
        Debug.Log("BRUTAL SWING APPLIED " + finalDamage + " DAMAGE TO " + target.name + " ✅");

        foreach(var effect in additionalEffects){
            effect.Apply(caster,target);
        }
    }


}
