using UnityEngine;

public class IronHide : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.ResilientShell);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new GuardiansAegis("Guardian's Aegis", 30, 1);
    }
}

