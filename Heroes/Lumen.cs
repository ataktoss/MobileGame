using UnityEngine;

public class Lumen : IFighter
{
    void Awake()
    {
        AddPassive(new FirstAid());
        fighterSpell = new RenewingWave("Renewing Wave", 20 , 30);
    }
}
