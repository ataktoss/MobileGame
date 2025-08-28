using UnityEngine;

public class Lumen : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.ArcaneBattery);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new RenewingWave("Renewing Wave", 20 , 20);
    }
}