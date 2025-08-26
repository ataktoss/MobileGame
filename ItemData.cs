using System.Collections.Generic;
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

    public int bonusAttackDamage;
    public float bonusAttackSpeed;
    public int bonusSpellPower;
    public int bonusLife;
    public int bonusMana;
    public float bonusCriticalChance;
    public float bonusCriticalDamage;
    public int shopCost;
    public int shopSellValue;

    public List<ItemEffect> itemEffects;
    public ItemRarity itemRarity;

    public void RunBeforeAttack(Fighter fighter,Fighter target,int damage,bool isCrit){
        foreach(var effect in itemEffects){
            effect.OnBeforeAttack(fighter, target, damage, isCrit);
        }
    }
    public void RunAfterAttack(Fighter fighter,Fighter target,int damage,bool isCrit){
        foreach(var effect in itemEffects){
            effect.OnAfterAttack(fighter, target, damage, isCrit);
        }
    }
    public void OnSpellCast(Fighter fighter,Fighter target,int damage,int spellPower){
        foreach(var effect in itemEffects){
            effect.OnSpellCast(fighter, target, spellPower);
        }
    }
    
    public virtual void OnEquip(Fighter fighter) { }

    public virtual void OnAttack(Fighter fighter){}

    public virtual void OnSpellCast(Fighter caster, Spell spell, Fighter target){}
    
}
