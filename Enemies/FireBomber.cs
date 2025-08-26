using UnityEngine;

public class FireBomber : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.Shockwave);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
