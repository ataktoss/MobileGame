using UnityEngine;

public class VirulentBurst: Spell
{
    public VirulentBurst(string name,int manaCost,int damage):base("Virulent Burst",20,1){}

    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        foreach(var enemy in CombatManager.Instance.GetMonsterList()){
            if(enemy == null || !enemy.isAlive) continue;
            enemy.ApplyDebuff(new PoisonEffect(Mathf.RoundToInt(caster.attackDamage*0.2f),3,1));
            enemy.ApplyDebuff(new PoisonEffect(Mathf.RoundToInt(caster.attackDamage*0.2f),3,1));
        }
    }



}
