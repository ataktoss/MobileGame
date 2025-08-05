using UnityEngine;

public class ShadowBlade : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.LonePredator);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new RelentlessStrikes("Relentless Strikes", 30, 50);


    }
}

