using System;
using UnityEngine;

public class Ember : Fighter
{
    void Awake(){
        AddPassive(new ArcaneFlow("Arcane Flow","Get +5 mana on attack"));
        fighterSpell = new FireBall("Fireball",25,30);
    }
}
