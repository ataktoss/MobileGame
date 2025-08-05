using UnityEngine;

public class VenomFang : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.ToxicPrecision);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new SilentEdge("Silent Edge", 15, 5);
    }
}
