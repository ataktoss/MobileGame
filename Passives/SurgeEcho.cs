using UnityEngine;

public class SurgeEcho : Passive, IEffect
{

    private int numberOfSpellsCast = 0;

    public SurgeEcho(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        numberOfSpellsCast++;
        if (numberOfSpellsCast >= 3)
        {
            numberOfSpellsCast = 0;
            fighter.CastSpell(new ChainLightning("ChainLightning", 0, 0), fighter);
            
        }
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
