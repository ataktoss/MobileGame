using UnityEngine;

public class GiefPassive : MonoBehaviour
{
    
    public IFighter fighter;
    private Passive testPassive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testPassive = new HealOnDamagePassive();
        fighter.AddPassive(testPassive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
