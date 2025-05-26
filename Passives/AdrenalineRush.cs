using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class AdrenalineRush : Passive,IEffect
{
    float attackSpeedBoost = 0.3f;

    public AdrenalineRush():base("AdrenalineRush","Gain +30% attack speed while below 50% life"){}

    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        bool hasBuff = fighter.activeEffects.Any(e => e is AdrenalineRushBuff);
        if(fighter._currentLife<= fighter.life/2){
            
            if(hasBuff) return;
            Apply(null,fighter);
        }
        if(fighter._currentLife>= fighter.life/2){
            
            if(hasBuff){
                fighter.RemoveBuff<AdrenalineRushBuff>();
                
            }
            
        }
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }

    public void Apply(Fighter caster, Fighter target)
    {
        target.ApplyDebuff(new AdrenalineRushBuff(attackSpeedBoost,50,1));
    }
}
