using UnityEngine;

public class ManaFlow : Passive
{
    
    public ManaFlow():base("Mana Flow","Gain mana every few seconds"){}

    public override void ApplyEffect(IFighter fighter)
    {
        fighter.ApplyDebuff(new ManaFlowBuff(5,200,2));
    }
}
