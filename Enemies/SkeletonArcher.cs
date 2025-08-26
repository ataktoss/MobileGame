using UnityEngine;

public class SkeletonArcher : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.EchoFang);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
