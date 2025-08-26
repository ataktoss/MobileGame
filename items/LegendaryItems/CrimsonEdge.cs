using UnityEngine;

[CreateAssetMenu(fileName = "CrimsonEdge", menuName = "ItemEffects/CrimsonEdge")]
public class CrimsonEdge : ItemEffect
{
    public override void OnAfterAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        int bleedDamage = Mathf.RoundToInt(attacker.TotalAttackDamage * 0.2f);
        target.ApplyDebuff(new BleedEffect(bleedDamage, 3, 1));
    }
}
