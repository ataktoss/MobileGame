using UnityEngine;

public class QuickHands : Passive
{
    public QuickHands():base("Quick Hands","Gain +20% Attack Speed"){}

    public override void ApplyEffect(Fighter fighter)
    {
        fighter.attackSpeed *= 1.2f;
    }
}
