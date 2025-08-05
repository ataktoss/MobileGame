using UnityEngine;

public class BurnOut : Passive, IEffect
{
    public BurnOut():base("BurnOut","After casting a spell your next Auto Attack deals +40% Damage"){}

    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public int currentAttackNumber = 0;
    public int currentAttackPlusOne;

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        currentAttackNumber = fighter.numberOfAttacks;
        fighter.ApplyDebuff(new BurnOutBuff(1.4f,100,1));
    }


    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        if(currentAttackNumber >= currentAttackNumber+1){
            //fighter.outgoingDamageModifiers.Remove()
            fighter.RemoveBuff<BurnOutBuff>();
        }
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
