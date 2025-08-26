using UnityEngine;

public class BigBlob : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.SecondWind);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
