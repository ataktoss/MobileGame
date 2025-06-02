using UnityEngine;

[CreateAssetMenu(fileName = "PassiveData", menuName = "Scriptable Objects/PassiveData")]
public class PassiveData : ScriptableObject
{
    public string passiveId;
    public string passiveName;
    public string description;
    public Sprite icon;
}
