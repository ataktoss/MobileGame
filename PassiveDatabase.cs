using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PassiveDatabase", menuName = "RPG/Passive Database")]
public class PassiveDatabase : ScriptableObject
{
    public List<PassiveData> allPassives;
}
