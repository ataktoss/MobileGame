using UnityEngine;

public class Shockwave : Passive, IEffect
{

    public Shockwave(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        int shockwaveDamage = (int)(damage * 0.2f);
        foreach(var hero in CombatManager.Instance.GetHeroList())
        {
            if(hero != null && hero.isAlive)
            {
                hero.TakeDamage(shockwaveDamage,fighter);
            }
        }
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

    }
    

}
