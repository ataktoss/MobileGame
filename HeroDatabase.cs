using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class HeroDatabase : MonoBehaviour
{

    public List<GameObject> heroes;

    public GameObject GetRandomHero()
    {
        if (heroes.Count == 0) return null;

        List<GameObject> currentFighters = new();
        foreach (var hero in CombatManager.Instance.currentTeam)
        {
            GameObject fighter = hero.prefab;
            if (fighter != null)
            {
                currentFighters.Add(fighter);
            }
        }
        List<GameObject> availableHeroes = heroes.Except(currentFighters).ToList();
        GameObject randomHero = availableHeroes[Random.Range(0, availableHeroes.Count)];

        return randomHero;
    }

    public List<GameObject> GetRandomHeroes(int count)
    {
        List<GameObject> currentHeroes = heroes.Except(CombatManager.Instance.currentTeam.Select(h => h.prefab)).ToList();

        return currentHeroes.OrderBy(x => Random.value).Take(count).ToList();
    }


}
