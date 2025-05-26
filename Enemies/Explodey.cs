using UnityEngine;

public class Explodey : Fighter
{
    void Awake()
    {
        AddPassive(new RotBurst(30));
    }
}
