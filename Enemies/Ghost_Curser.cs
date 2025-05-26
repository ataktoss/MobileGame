using UnityEngine;

public class Ghost_Curser : Fighter
{
    void Awake()
    {
        AddPassive(new WitchCurse(2));
    }
}
