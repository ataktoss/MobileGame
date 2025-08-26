using UnityEngine;

public class ShadowStalker : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.OpeningGambit);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}

