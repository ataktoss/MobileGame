using UnityEngine;

public class KillersEdge : Passive, IEffect
{
    // If target lower than 30% health, deal double damage
    public KillersEdge(PassiveData data) : base(data)
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
        if(target._currentLife < target.TotalLife * 0.3f)
        {
            damage = (int)(damage * 2f);
        }

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
