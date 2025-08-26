using UnityEngine;

public class CullingInstinct : Passive, IEffect
{
    //Deal 10% more damage for each enemy alive
    public CullingInstinct(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        

    }
    public override void OnCrit(Fighter fighter,Fighter target,int damage,bool isCritical)
    {
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {

    }

    public override int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage; 
    }
    public override int ModifyDamageDone(Fighter fighter,Fighter target, int damage)
    {
        int numberOfEnemiesAlive = CombatManager.Instance.GetMonsterList().Count;
        return Mathf.RoundToInt(damage * (1 + 0.1f * numberOfEnemiesAlive));
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {

    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
