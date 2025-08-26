using System;
using UnityEngine;

public class PoisonHits : Passive, IEffect
{
    
    

    public PoisonHits(PassiveData data):base(data){
        
    }

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        int theDamage = Mathf.RoundToInt(fighter.TotalAttackDamage*0.2f/3);
        target.ApplyDebuff(new PoisonEffect(theDamage,2,1));
    }

}
