using UnityEngine;

public class BattleRythm : Spell
{
    public BattleRythm(string name, int manaCost, int damage) : base(name, manaCost, damage)
    {
    }

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        foreach (var hero in CombatManager.Instance.GetHeroList())
        {
            if (hero == null || !hero.isAlive) continue;

            
            hero.ApplyDebuff(new AttackSpeedBuff(0.2f, 6,1)); // Example duration and frequency
        }
            
        
    }
}
