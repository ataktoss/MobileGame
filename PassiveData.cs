using UnityEngine;

public enum PassiveType
{
    AdrenalineRush,
    ArcaneFlow,
    LeechingBlows,
    FirstAid,
    LonePredator,
    ResilientShell,
    ToxicPrecision,
    Spellash,
    EchoFang,
    Spellweaver,
    IronRhythm
    // Add all passives here
}

[CreateAssetMenu(fileName = "New Passive", menuName = "RPG/Passive")]
public class PassiveData : ScriptableObject
{
    public string passiveName;
    public string description;
    public Sprite icon;
    public PassiveType type;
}
