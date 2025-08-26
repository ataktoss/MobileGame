using UnityEngine;

public class Heartcleaver : Passive, IEffect
{
    // On attack, deal 5% of target's max health as bonus damage
    public Heartcleaver(PassiveData data) : base(data)
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
        int bonusDamage = Mathf.RoundToInt(target.life * 0.05f); // 5% of target's max health

        return damage + bonusDamage;
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
