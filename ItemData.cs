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

    public int bonusAttackSpeed;
    public int bonusSpellPower;
    public int bonusLife;
    public int bonusMana;

    public ItemRarity itemRarity;


    public virtual void OnEquip(IFighter fighter){}

    public virtual void OnAttack(IFighter fighter){}

    public virtual void OnSpellCast(IFighter caster, Spell spell, IFighter target){}
    
}
