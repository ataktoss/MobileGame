using UnityEngine;

public class RuneBreaker : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.Spellash);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        fighterSpell = new ArcanePulse("Arcane Pulse", 15, 5);
    }
}
