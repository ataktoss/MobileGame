using UnityEngine;

[CreateAssetMenu(fileName = "ExecutionersCrit", menuName = "ItemEffects/ExecutionersCrit")]
public class ExecutionersCrit : ItemEffect
{
    
    public override int OnBeforeAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        if (isCrit)
        {
            damage *= 2;
        }


        return damage;
    }

}
