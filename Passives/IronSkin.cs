using System;
using UnityEngine;

public class IronSkin : Passive, IEffect
{
    

    public IronSkin(int leechAmount):base("",""){
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        fighter.ApplyDebuff(new IronSkinBuff(2, 1));
        
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
}
