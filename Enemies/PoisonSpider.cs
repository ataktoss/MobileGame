using UnityEngine;

public class PoisonSpider : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.PoisonHits);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
