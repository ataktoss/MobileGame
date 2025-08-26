using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ScriptableObjects/ItemEffect")]
public abstract class ItemEffect : ScriptableObject
{
    public virtual int OnBeforeAttack(Fighter attacker, Fighter target, int damage, bool isCrit) { return damage; }
    public virtual void OnAfterAttack(Fighter attacker, Fighter target, int damage, bool isCrit) { }
    public virtual void OnSpellCast(Fighter caster, Fighter target, int spellPower) { }
    



}
