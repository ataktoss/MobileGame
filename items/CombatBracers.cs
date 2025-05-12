using UnityEngine;

public class CombatBracers : Item
{
    public CombatBracers(){
        itemName = "Combat Bracers";
        itemID = "combat_bracers";
        description = "Gain +10% attack speed + 10 life";
        bonusAttackSpeed = 10;
        bonusLife = 10;
        
    }
    
}
