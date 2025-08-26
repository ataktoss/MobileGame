using UnityEngine;

public class EchoFang : Passive, IEffect
{
    //Chance to Attack twice on attack
    public EchoFang(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        bool chanceToAttackTwice = UnityEngine.Random.value < 0.05f; 
        if (chanceToAttackTwice)
        {
            fighter.Attack(target, damage);
        }
        
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
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
