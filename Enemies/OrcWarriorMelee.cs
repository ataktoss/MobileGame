using UnityEngine;

public class OrcWarriorMelee : Fighter
{
    

    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.BerserkersTempo);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
    }
}
