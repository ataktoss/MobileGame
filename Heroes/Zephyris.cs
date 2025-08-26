using UnityEngine;

public class Zephyris : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.RallyingWinds);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new EmpoweringHymn("Empowering Hymn", 20, 0);
    }
}
