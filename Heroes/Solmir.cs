using UnityEngine;

public class Solmir : Fighter
{
    void Awake()
    {
        AddPassive(new ArcaneEcho());
        fighterSpell = new ManaFlare("Mana Flare", 25, 0);
    }
}
