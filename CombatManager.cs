using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    
    
    public List<Hero> heroes = new List<Hero>();
    public List<Monster> monsters = new List<Monster>();
    
    
    private float timer = 0f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        


        heroes[0].StartAttack(monsters[0]);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if(timer>= )
    }
}
