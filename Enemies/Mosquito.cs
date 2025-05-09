using UnityEngine;

public class Mosquito : IFighter
{
    void Awake()
    {
        AddPassive(new LeechingBlows(0.3f));
    }
}
