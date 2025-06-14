using UnityEngine;




public enum ItemRarity{
    Common,
    Rare,
    Epic,
    Legendary
}



[CreateAssetMenu(fileName = "New Item", menuName = "Items/GenericItem")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;

    public float bonusAttackSpeed;
    public int bonusSpellPower;
    public int bonusLife;
    public int bonusMana;

    public ItemRarity itemRarity;


    public virtual void OnEquip(Fighter fighter){}

    public virtual void OnAttack(Fighter fighter){}

    public virtual void OnSpellCast(Fighter caster, Spell spell, Fighter target){}
    
}
