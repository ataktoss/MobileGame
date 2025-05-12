using UnityEngine;

public class Thresher : IFighter
{
    void Awake(){
        AddPassive(new FeastOnPain());
        fighterSpell = new BrutalSwing("Brutal Swing", 20,1);
    }
}
