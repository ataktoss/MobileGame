using UnityEngine;


[CreateAssetMenu(fileName = "BrutalHits", menuName = "ItemEffects/BrutalHits")]
public class BrutalHits : ItemEffect
{
    public override int OnBeforeAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        int flatDamageAmount = 50;
        return damage + flatDamageAmount;
    }
}
