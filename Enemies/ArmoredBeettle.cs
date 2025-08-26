using UnityEngine;

public class ArmoredBeettle : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.Unyielding);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
