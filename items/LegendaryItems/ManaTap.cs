using UnityEngine;

[CreateAssetMenu(fileName = "ManaTap", menuName = "ItemEffects/ManaTap")]
public class ManaTap : ItemEffect
{
    public override void OnAfterAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        attacker.ChangeMana(5);
    }
}
