using UnityEngine;

public class Bloodtide : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.KillersEdge);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new BloodPact("Blood Surge", 20, 25);
    }
}

