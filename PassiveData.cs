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
    IronRhythm,
    Heartcleaver,
    KillersEdge,
    FortifiedHeart,
    BerserkersTempo,
    SoothingLight,
    SerratedStrikes,
    PoisonHits,
    BloodFeast,
    SecondWind,
    RotBurst,
    Unyielding,
    OpeningGambit,
    ThornGuard,
    BerserkersFrenzy,
    Shockwave,
    FirstAidEnemy,
    SurgeEcho,
    RallyingWinds,
    LingeringCurse,
    VitalWrath,
    ArcanizedSteel,
    WoundingBlows,
    VoidFang,
    BloodFrenzy,
    RecklessFury,
    CullingInstinct,
    WeakenedResolve,
    ArcaneBattery,
    MarkOfAgony,
    PredatorsHunger,
    PainResponse,
    StoicBarrier,
    GamblersEdge
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
