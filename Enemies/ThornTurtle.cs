using UnityEngine;

public class ThornTurtle : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.ThornGuard);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
