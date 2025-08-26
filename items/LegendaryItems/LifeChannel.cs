using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeChannel", menuName = "ItemEffects/LifeChannel")]
public class LifeChannel : ItemEffect
{
    public override void OnSpellCast(Fighter attacker, Fighter target, int damage)
    {
        int heroLife = int.MaxValue;
        Fighter lowestLifeFighter = null;
        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            if (hero == null) continue;
            if (hero._currentLife < heroLife)
            {
                lowestLifeFighter = hero;
            }
        }
        if (lowestLifeFighter != null)
        {
            lowestLifeFighter.Heal(Mathf.RoundToInt(damage * 0.5f));
        }
    }
}
