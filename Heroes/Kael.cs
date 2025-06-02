using UnityEngine;

public class Kael : Fighter
{
    void Awake()
    {
        AddPassive(new Opportunist());
        fighterSpell = new FocusedStrike("Focused Strike", 25, 0);
    }
    
}
