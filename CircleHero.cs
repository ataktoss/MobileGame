using Unity.VisualScripting;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CircleHero: IFighter
{


    void Awake()
    {
        //fighterSpell = new FireBall("fireball",50,10);
        fighterSpell = new HealLowest("Serenity",25,50);

    }












}
