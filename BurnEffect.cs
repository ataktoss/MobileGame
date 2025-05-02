using UnityEngine;

public class BurnEffect : StatusEffect
{
    
    public int damagePerTurn;

    public BurnEffect(int damagePerTurn, int duration): base("Burn",duration){
        this.damagePerTurn = damagePerTurn;
    }

    public override void OnAPply(IFighter target)
    {
        Debug.Log(target.unitName + " Is now burning");
    }

    



}
