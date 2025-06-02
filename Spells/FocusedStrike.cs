using UnityEngine;

public class FocusedStrike : Spell
{
    public FocusedStrike(string name, int manaCost, int cooldown) : base(name, manaCost, cooldown)
    {
    }

    public override void ApplyEffect(Fighter caster,Fighter target,float spellPower){
        caster.ApplyDebuff(new BurnOutBuff(2, 200, 1));
    }
}
