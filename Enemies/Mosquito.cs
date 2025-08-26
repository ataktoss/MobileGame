using UnityEngine;

public class Mosquito : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.BloodFeast);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
