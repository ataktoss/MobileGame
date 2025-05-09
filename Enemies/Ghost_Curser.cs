using UnityEngine;

public class Ghost_Curser : IFighter
{
    void Awake()
    {
        AddPassive(new WitchCurse(2));
    }
}
