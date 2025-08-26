using UnityEngine;

public class ArcaneBattery : Passive, IEffect
{
    //On spell cast give 10 mana to all heroes
    public ArcaneBattery(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }
    public override void OnCrit(Fighter fighter,Fighter target,int damage,bool isCritical)
    {
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        foreach(var hero in CombatManager.Instance.GetHeroList()){
            if(hero.isAlive && hero != null){
                hero.ChangeMana(10);
            }
        }
    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        return damage; 
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {

    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
