using UnityEngine;

public class GiefPassive : MonoBehaviour
{
    
    public Fighter fighter;
    private Passive testPassive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testPassive = new AdrenalineRush();
        fighter.AddPassive(testPassive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
