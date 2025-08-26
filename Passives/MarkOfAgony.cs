using UnityEngine;

public class MarkOfAgony : Passive, IEffect
{

    //Every 3rd attacks applies vulnerable
    int numberOfAttacks = 0;
    public MarkOfAgony(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        numberOfAttacks++;
        if (numberOfAttacks >= 3)
        {
            target.ApplyDebuff(new VulnerableEffect(200, 1, 1.1f));
        }
    }
    public override void OnCrit(Fighter fighter,Fighter target,int damage,bool isCritical)
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
