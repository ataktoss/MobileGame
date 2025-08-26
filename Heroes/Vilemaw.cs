using UnityEngine;

public class Vilemaw : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.BerserkersTempo);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new PredatorsFrenzy("Predators Frenzy", 20, 20);
    }
}
