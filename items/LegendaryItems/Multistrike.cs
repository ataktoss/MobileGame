using UnityEngine;

[CreateAssetMenu(fileName = "Multistrike", menuName = "ItemEffects/Multistrike")]
public class Multistrike : ItemEffect
{
    int numberOfAttacks = 0;
    public override int OnBeforeAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        numberOfAttacks++;
        if (numberOfAttacks >= 5)
        {
            return Mathf.RoundToInt(damage * 2f); 
        }

        return damage;
    }
}
