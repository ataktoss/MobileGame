using UnityEngine;

public class CleansePulse : Passive,IEffect
{
    public CleansePulse():base("Cleanse Pulse","Cleanse 1 debuff from an ally every 5 seconds"){}

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            hero.ApplyDebuff(new CleanseBuff(0,200,7));
        }
    }
}
