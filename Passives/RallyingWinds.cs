using UnityEngine;

public class RallyingWinds : Passive, IEffect
{
    //Give 10% crit chance to all allies
    public RallyingWinds(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        return damage; 
    }

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {
        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            if(hero == null) continue;

            hero.critChance += 0.1f;
        }
    }
    

}
