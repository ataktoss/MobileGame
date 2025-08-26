using UnityEngine;


[CreateAssetMenu(fileName = "GiantSlayer", menuName = "ItemEffects/GiantSlayer")]
public class GiantSlayer : ItemEffect
{
    public override int OnBeforeAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        int bonusDamage = Mathf.RoundToInt(target._currentLife * 0.05f);

        return damage + bonusDamage;
    }
}
