using Unity.VisualScripting;
using UnityEngine;

public class HealOnDamagePassive : Passive
{

    public HealOnDamagePassive():base(
        "Second Wind",
        "When you take damage Heal"
    ){}

    public override void ApplyEffect(Hero hero)
    {
        
        hero.CustomEffect(()=>{
            Debug.Log("This heroes name is : " + hero.name);
        });

    }
    
}
