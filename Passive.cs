using UnityEngine;

[System.Serializable]
public abstract class Passive
{
    public string passiveName;
    public string description;
    public Sprite icon;

    // Original constructor (optional fallback)
    protected Passive(string name, string desc)
    {
        passiveName = name;
        description = desc;
    }

    // New constructor using PassiveData ScriptableObject
    protected Passive(PassiveData data)
    {
        passiveName = data.passiveName;
        description = data.description;
        icon = data.icon;

        if (icon == null)
        Debug.LogError($"[Passive] Icon is NULL for: {passiveName}");
    }

    // Apply passive once per fight
    public abstract void ApplyEffect(Fighter fighter);

    // Optional hooks – override as needed
    public virtual int ModifyDamageTaken(Fighter fighter, int damage)
    {
        return damage;
    }
    public virtual int ModifyDamageDone(Fighter fighter, Fighter target,int damage)
    {
        // Default implementation does nothing
        return damage;
    }
    public virtual void OnTakeDamage(Fighter fighter,Fighter attacker, int damage) { }
    public virtual void OnAttack(Fighter fighter, Fighter target, int damage) { }
    public virtual void OnCrit(Fighter fighter,Fighter target,int damage, bool isCritical) { }
    public virtual void OnSpellCast(Fighter fighter, int manaCost) { }
    public virtual void OnDeath(Fighter fighter) { }
}
