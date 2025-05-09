using UnityEngine;

public class Spider : IFighter
{

    void Awake()
    {
        AddPassive(new PoisonHits(5));
    }

}
