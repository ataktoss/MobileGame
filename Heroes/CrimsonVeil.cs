using UnityEngine;

public class CrimsonVeil : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.SerratedStrikes);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new ExecutionersEdge("Brutal Surge", 25, 1);
    }
}

