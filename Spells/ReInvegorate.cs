using UnityEngine;

public class ReInvegorate : Spell
{
    public ReInvegorate(string name, int manaCost, int cooldown) : base(name, manaCost, cooldown)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        for(int i = caster.activeEffects.Count -1; i>=0; i--){
            if(caster.activeEffects[i].effectType == StatusEffect.StatusEffectType.Debuff){
                caster.activeEffects[i].OnExpire(caster);
                caster.activeEffects.RemoveAt(i);
                caster.Heal(Mathf.RoundToInt(caster.life * 0.1f));
            }
        }
    }
}

