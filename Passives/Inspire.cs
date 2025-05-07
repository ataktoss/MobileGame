using UnityEngine;

public class Inspire: Passive
{
    public Inspire():base("Inspire","Allies gain +10% attack speed"){}

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero != fighter){
                hero.attackSpeed *= 1.1f;
            }
        }
    }
}
