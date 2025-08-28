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
        // Filter out heroes already in the current team
        List<GameObject> availableHeroes = heroes
            .Except(CombatManager.Instance.currentTeam.Select(h => h.prefab))
            .ToList();

        if (availableHeroes.Count < count)
            return availableHeroes; // Not enough heroes left

        List<GameObject> selectedHeroes = new();

        // Helper function to pick one from a type
        GameObject PickOne(FighterType type)
        {
            var candidates = availableHeroes
                .Where(h => h.GetComponent<Fighter>().fighterType == type)
                .ToList();
            if (candidates.Count == 0) return null;
            var chosen = candidates[Random.Range(0, candidates.Count)];
            availableHeroes.Remove(chosen);
            return chosen;
        }

        // 1 Tank
        var tank = PickOne(FighterType.Tank);
        if (tank != null) selectedHeroes.Add(tank);

        // 1 Support
        var support = PickOne(FighterType.Support);
        if (support != null) selectedHeroes.Add(support);

        // 1 Random from Assassin/Mage/Fighter
        var dpsTypes = new[] { FighterType.Assassin, FighterType.Mage, FighterType.Fighter };
        var dpsCandidates = availableHeroes
            .Where(h => dpsTypes.Contains(h.GetComponent<Fighter>().fighterType))
            .ToList();
        if (dpsCandidates.Count > 0)
        {
            var chosen = dpsCandidates[Random.Range(0, dpsCandidates.Count)];
            availableHeroes.Remove(chosen);
            selectedHeroes.Add(chosen);
        }

        // If count > 3, fill randomly from leftovers
        if (selectedHeroes.Count < count)
        {
            var extra = availableHeroes
                .OrderBy(x => Random.value)
                .Take(count - selectedHeroes.Count);
            selectedHeroes.AddRange(extra);
        }

        return selectedHeroes;
    }


}
