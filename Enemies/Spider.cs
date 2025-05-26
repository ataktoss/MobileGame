using UnityEngine;

public class Spider : Fighter
{

    void Awake()
    {
        AddPassive(new PoisonHits(5));
    }

}
