using UnityEngine;

public class Gorran : Fighter
{
    void Awake()
    {
        AddPassive(new FortifiedStance());
        fighterSpell = new ReInvegorate("Reinvigorate", 25, 0);
    }
}
