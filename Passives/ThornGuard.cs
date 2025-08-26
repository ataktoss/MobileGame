using UnityEngine;

public class ThornGuard : Passive, IEffect
{
    float lastUsedTime = 0f;
    public ThornGuard(PassiveData data) : base(data)
    {

    }

    public override void OnAttack(Fighter fighter, Fighter target, int damage)
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
        return damage; 
    }

    public override void OnTakeDamage(Fighter fighter,Fighter attacker, int damage)
    {
        float currentTime = Time.time;
        float passiveCooldown = 2f;
        
        if (currentTime > lastUsedTime + passiveCooldown)
        {

            lastUsedTime = currentTime;
            int reflectAmount = Mathf.RoundToInt(damage * 0.1f); // Reflect 10% of the damage taken
            attacker.TakeDamage(reflectAmount,attacker);
        }
        else
        {
            return; // Passive is on cooldown, do nothing
        }

        
    }


    public void Apply(Fighter caster, Fighter target)
    {

    }

    public override void ApplyEffect(Fighter fighter)
    {

    }
    

}
