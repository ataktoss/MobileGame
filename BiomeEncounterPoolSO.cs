using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Combat/Biome Encounter Pool")]
public class BiomeEncounterPoolSO : ScriptableObject
{
    public string biomeName;

    public List<EncounterGroupSO> normalEncounters;
    public List<EncounterGroupSO> eliteEncounters;
    public List<EncounterGroupSO> bossEncounters;
}

