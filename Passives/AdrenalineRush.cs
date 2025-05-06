using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class AdrenalineRush : Passive,IEffect
{
    float attackSpeedBoost = 0.3f;

    public AdrenalineRush():base("AdrenalineRush","Gain +30% attack speed while below 50% life"){}

    public override void OnTakeDamage(IFighter fighter, int damage)
    {
        bool hasBuff = fighter.activeEffects.Any(e => e is AdrenalineRushBuff);
        if(fighter._currentLife<= fighter.life/2){
            
            if(hasBuff) return;
            Apply(null,fighter);
        }
        if(fighter._currentLife>= fighter.life/2){
            
            if(hasBuff){
                fighter.activeEffects.RemoveAll(e => e is AdrenalineRushBuff);
                
            }
            
        }
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }

    public void Apply(IFighter caster, IFighter target)
    {
        target.ApplyDebuff(new AdrenalineRushBuff(attackSpeedBoost,50,1));
    }
}
