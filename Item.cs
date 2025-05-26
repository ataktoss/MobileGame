using UnityEngine;


public class Item
{
    
    public string itemName;
    public string itemID;
    public string description;

    public int bonusAttackSpeed;
    public int bonusSpellPower;
    public int bonusLife;
    public int bonusMana;


    public virtual void OnEquipd(Fighter fighter){}
    public virtual void OnAttack(Fighter attacker,Fighter target){}
    
    //CAN ADD ON SPELLCAST,CRIT ETC if needed alla kata protimisi tha ta kanw auta meso buffs kai oxi edw pera


}
