using UnityEngine;

public class WitchCurse : Passive, IEffect
{
    public int curseAmount;
    private int attackTracker = 0;

    public WitchCurse(int curseAmount):base("WitchCurse","Every 3 hits applies a curse that increases damage taken"){
        this.curseAmount = curseAmount;
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        attackTracker++;
        if(attackTracker>= 3){
            target.ApplyDebuff(new CurseEffect(1.2f,5,1));
            attackTracker = 0;
        }
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
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

    public override void OnDeath(Fighter fighter)
    {
        
    }
}
