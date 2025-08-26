using UnityEngine;

public class Gorebrand : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.Heartcleaver);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new BrutalSurge("Brutal Surge", 20, 20);
    }
}
