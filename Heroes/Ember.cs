using System;
using UnityEngine;

public class Ember : Fighter
{
    void Awake(){
        AddPassive(new ArcaneFlow());
        fighterSpell = new FireBall("Fireball",25,30);
    }
}
