using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveDatabase1", menuName = "Scriptable Objects/PassiveDatabase1")]
public class PassiveDatabase1 : ScriptableObject
{
    public List<PassiveData> allPassives;
}
