using UnityEngine;

public class Vexra : Fighter
{
    void Awake()
    {
        AddPassive(new ToxicPrecision());
        fighterSpell = new SilentEdge("Silent Edge", 25, 0);
    }
}
