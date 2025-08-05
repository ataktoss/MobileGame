using UnityEngine;

public class Spellweaver : Passive, IEffect
{

    Spell autoAttackSpell = new SpellWeaverSpell("Spellweaver Spell", 0, 0); 
    public Spellweaver(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        fighter.CastSpell(autoAttackSpell, target);
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter, Fighter target, int damage)
    {
        return damage;
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
