using UnityEngine;

public class Lumen : Fighter
{
    void Awake()
    {
        AddPassive(new FirstAid());
        fighterSpell = new RenewingWave("Renewing Wave", 20 , 30);
    }
}
