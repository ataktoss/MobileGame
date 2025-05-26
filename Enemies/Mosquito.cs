using UnityEngine;

public class Mosquito : Fighter
{
    void Awake()
    {
        AddPassive(new LeechingBlows(0.3f));
    }
}
