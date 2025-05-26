using System;
using Unity.Mathematics;
using UnityEngine;

public class IronBody : Passive
{
    public IronBody():base("IronBody","+20% max HP"){}

    public override void ApplyEffect(Fighter fighter)
    {
        Debug.Log("IronBody");
        fighter.life  = Mathf.RoundToInt(fighter.life * 1.2f);
        fighter.Heal(fighter.life);
    }

}
