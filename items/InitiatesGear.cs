using UnityEngine;

public class InitiatesGear : Item
{

    public InitiatesGear(){
        itemName = "Initiate's Gear";
        itemID= "initiates_gear";
        description = "+10 to everything";
        bonusAttackSpeed = 10;
        bonusSpellPower = 10;
        bonusLife = 10;
    }
}
