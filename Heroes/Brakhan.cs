using UnityEngine;

public class Brakhan : Fighter
{
    void Awake()
    {
        AddPassive(new EchoShot());
        fighterSpell = new FlurryVolley("Flurry Volley", 30, 0);
    }
}
