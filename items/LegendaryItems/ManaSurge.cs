using UnityEngine;

[CreateAssetMenu(fileName = "ManaSurge", menuName = "ItemEffects/ManaSurge")]
public class ManaSurge : ItemEffect
{
    public override void OnAfterAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        if (isCrit)
        {
            attacker.ChangeMana(10);
        }
    }
}
