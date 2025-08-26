using UnityEngine;

[CreateAssetMenu(fileName = "ArcaneGift", menuName = "ItemEffects/ArcaneGift")]
public class ArcaneGift : ItemEffect
{
    public override void OnSpellCast(Fighter caster, Fighter target, int spellPower)
    {
        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            hero.spellPower += 50;
        }
    }


}

