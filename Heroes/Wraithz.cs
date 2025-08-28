using UnityEngine;

public class Wraithz : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.LingeringCurse);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new Inspiration("Inspiration", 25 , 20);
    }
}
