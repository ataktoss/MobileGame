using UnityEngine;

[CreateAssetMenu(fileName = "HealingWave", menuName = "ItemEffects/HealingWave")]
public class HealingWave : ItemEffect
{

    public override void OnSpellCast(Fighter caster, Fighter target, int spellPower)
    {
        Fighter lowestFighter = null;
        int lowestLife = int.MaxValue;
        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            if (hero._currentLife < lowestLife && hero._currentLife > 0)
            {
                lowestLife = hero._currentLife;
                lowestFighter = hero;
            }
        }
        lowestFighter.Heal(Mathf.RoundToInt(lowestFighter.TotalLife * 0.2f));


    }
}
