using UnityEngine;

public class Soraka : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.FirstAidEnemy);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
