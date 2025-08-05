using UnityEngine;

public class Whirlcut : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.EchoFang);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new BladeStormFlurry("BladestormFlurry", 25, 5);
    }
}

