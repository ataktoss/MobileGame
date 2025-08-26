using UnityEngine;

public class BerserkerZero : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.BerserkersFrenzy);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
