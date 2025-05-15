using System.Collections.Generic;
using UnityEngine;


public class HeroDatabase : MonoBehaviour
{

    public List<GameObject> heroes;

    public GameObject GetRandomHero()
    {
        if (heroes.Count == 0) return null;
        return heroes[Random.Range(0, heroes.Count)];
    }


}
