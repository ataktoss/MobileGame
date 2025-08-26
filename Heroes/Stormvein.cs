using UnityEngine;

public class Stormvein : Fighter
{


    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.SurgeEcho);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new LightningBolt("Lightning Bolt", 30, 20);
    }

}

