using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    
    
    public List<Hero> heroes = new List<Hero>();
    public List<Monster> monsters = new List<Monster>();
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heroes[0].Attack(monsters[0],15);
        monsters[0].Attack(heroes[0],3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
