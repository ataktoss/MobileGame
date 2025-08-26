using UnityEngine;

[CreateAssetMenu(fileName = "EchoStrike", menuName = "ItemEffects/SpellEchoes")]
public class SpellEchoes : ItemEffect
{
    public override void OnSpellCast(Fighter attacker, Fighter target, int damage)
    {
        foreach (var enemy in CombatManager.Instance.GetMonsterList())
        {
            if (enemy == null || enemy == target) continue;
            enemy.TakeDamage(Mathf.RoundToInt(damage * 0.5f), attacker);
        }
    }
}
