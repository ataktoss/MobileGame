using UnityEngine;

public class Astrape : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.Spellweaver);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        
        fighterSpell = new LightningBolt("LightningBolt", 25, 30);
    }
}

