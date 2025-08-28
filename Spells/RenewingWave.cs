using UnityEngine;

public class RenewingWave : Spell
{
    public RenewingWave(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int finalHeal = (int)(damage+(spellPower*0.5f));
        foreach(var weaken in target.damageDoneModifiers){
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
