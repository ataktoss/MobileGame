using UnityEngine;

public class Explodey : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.RotBurst);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
