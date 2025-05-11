using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEncounterGroup", menuName = "Combat/Encounter Group")]
public class EncounterGroupSO : ScriptableObject
{
    public string groupID;
    public EncounterType type;

    [Tooltip("List of enemy prefab references")]
    public List<GameObject> enemyPrefabs;
    

}

public enum EncounterType
{
    Normal,
    Elite,
    Boss
}