using UnityEngine;

public class Venin : Fighter
{
    void Awake(){
        int poisonDamage = Mathf.RoundToInt(attackDamage*0.2f);
        AddPassive(new PoisonHits(poisonDamage));
        fighterSpell = new VirulentBurst("VirulentBurst",20,1);
    }


    
}
