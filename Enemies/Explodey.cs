using UnityEngine;

public class Explodey : IFighter
{
    void Awake()
    {
        AddPassive(new RotBurst(30));
    }
}
