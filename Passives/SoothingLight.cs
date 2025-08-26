using UnityEngine;

public class SoothingLight : Passive, IEffect
{
    //Gives buff that heals lowest ally every 5 secons for 5% hp
    public SoothingLight(PassiveData data) : base(data)
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
        caster.ApplyDebuff(new FirstAidBuff(0.05f, 200, 3));
    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
