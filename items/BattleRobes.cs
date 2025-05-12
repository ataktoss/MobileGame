using UnityEngine;

public class BattleRobes: Item
{
    public BattleRobes(){
        itemName = "BattleRobes";
        itemID = "battlerobes";
        description = "Gain 30 hp + 10 spell power";
        bonusSpellPower = 10;
        bonusLife = 30;
    }
}
