using UnityEngine;

public class Ilaris :  Fighter
{
    void Awake()
    {
        AddPassive(new RunicPulse());
        fighterSpell = new FireBall("Fireball", 100, 20);
    }
}
