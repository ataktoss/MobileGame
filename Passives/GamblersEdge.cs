using UnityEngine;

public class GamblersEdge : Passive, IEffect
{

    public GamblersEdge(PassiveData data) : base(data)
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

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        float randomMultiplier = Random.Range(0.5f, 2f);
        return Mathf.RoundToInt(damage * randomMultiplier);
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
