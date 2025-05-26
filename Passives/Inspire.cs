using UnityEngine;

public class Inspire: Passive
{
    public Inspire():base("Inspire","Allies gain +10% attack speed"){}

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero != fighter){
                hero.attackSpeed *= 1.1f;
            }
        }
    }
}
