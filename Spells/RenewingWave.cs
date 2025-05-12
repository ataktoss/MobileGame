using UnityEngine;

public class RenewingWave : Spell
{
    public RenewingWave(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(IFighter caster, IFighter target, float spellPower)
    {
        int finalHeal = (int)(damage*(1+spellPower));
        foreach(var weaken in target.outgoingDamageModifiers){
            finalHeal = weaken(finalHeal);
        }
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero ==null || !hero.isAlive ) continue;
            if(hero){
                hero.Heal(finalHeal);
            }
        }

        foreach(var effect in additionalEffects){
            effect.Apply(caster,target);
        }
    }
}
