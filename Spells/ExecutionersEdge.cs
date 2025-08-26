using UnityEngine;

public class ExecutionersEdge : Spell
{


    public ExecutionersEdge(string name, int manaCost, int cooldown) : base(name, manaCost, cooldown)
    {

    }
    public override void ApplyEffect(Fighter caster, Fighter target, float spellPower)
    {
        int baseDamage = Mathf.RoundToInt(caster.TotalAttackDamage * 2f);
        if (target._currentLife < target.TotalLife * 0.3f)
        {
            target.Die();
        }
        else
        {
            target.TakeDamage(baseDamage,caster);
        }


    }


}
