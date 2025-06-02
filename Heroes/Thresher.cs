using UnityEngine;

public class Thresher : Fighter
{
    void Awake()
    {
        //AddPassive(new FeastOnPain());
        AddPassive(new IronBody());
        fighterSpell = new BrutalSwing("Brutal Swing", 20, 1);
        Debug.Log("Thresher used Awake to initialize the fighter.");
        Debug.Log("MY LIST OF PASSIVES AS THRESHER ARE :");
        foreach (var passive in passives)
        {
            Debug.Log(passive.passiveName + " Is the passive");
        }
    }
}
