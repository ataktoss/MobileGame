using UnityEngine;

public class Thresher : Fighter
{
    void Awake(){
        AddPassive(new FeastOnPain());
        fighterSpell = new BrutalSwing("Brutal Swing", 20,1);
    }
}
