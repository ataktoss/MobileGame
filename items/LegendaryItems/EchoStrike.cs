using UnityEngine;

[CreateAssetMenu(fileName = "EchoStrike", menuName = "ItemEffects/EchoStrike")]
public class EchoStrike : ItemEffect
{
    private int numberOfAttacks = 0;
    public override void OnAfterAttack(Fighter attacker, Fighter target, int damage, bool isCrit)
    {
        numberOfAttacks++;
        if (numberOfAttacks >= 4)
        {
            attacker.Attack(target, damage);
        }
    }

}
