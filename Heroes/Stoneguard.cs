using UnityEngine;

public class Stoneguard : Fighter
{
    void Awake()
    {
        PassiveData data = CombatManager.Instance.passiveDatabase.allPassives.Find(p => p.type == PassiveType.FortifiedHeart);
        Passive logic = PassiveFactory.Create(data);
        AddPassive(logic);
        //AddPassive(new FirstAid());
        fighterSpell = new GuardiansAegis("Guardians Aegis", 20, 0); // No damage, just a shield
    }
}
