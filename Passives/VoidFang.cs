using UnityEngine;

public class VoidFang : Passive, IEffect
{

    //After casting a spell next attacks deal bonus 40% damage
    int spellCasts = 0;
    public VoidFang(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {

    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        spellCasts++;
    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        if(spellCasts > 0)
        {
            damage = Mathf.RoundToInt(damage * 1.4f);
            spellCasts--;
        }
        return damage; 
    }

    


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
