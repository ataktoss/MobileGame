using UnityEngine;

[CreateAssetMenu(fileName = "RelentlessAssult", menuName = "ItemEffects/RelentlessAssult")]
public class RelentlessAssult : ItemEffect
{
    int numberOfAttacksOnTarget = 1;
    Fighter currentTarget = null;
    float damageMultiplier = 0.1f;

    public override int OnBeforeAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        if (currentTarget == target)
        {
            
            int bonusDamage = Mathf.RoundToInt(damage * damageMultiplier * numberOfAttacksOnTarget);
            numberOfAttacksOnTarget++;
            return damage + bonusDamage;
            
        }   
        currentTarget = target;
        numberOfAttacksOnTarget = 1;
        return damage;
    }
}
