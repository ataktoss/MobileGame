public static class PassiveFactory
{
    public static Passive Create(PassiveData data)
    {
        switch (data.type)
        {
            case PassiveType.AdrenalineRush:
                return new AdrenalineRush(data);
            case PassiveType.LeechingBlows:
                return new LeechingBlows(data);
            case PassiveType.FirstAid:
                return new FirstAid(data);  
            case PassiveType.LonePredator:
                return new LonePredator(data);
            case PassiveType.ResilientShell:
                return new ResilientShell(data);
            case PassiveType.ToxicPrecision:
                return new ToxicPrecision(data);
            case PassiveType.Spellash:
                return new Spellash(data);
            case PassiveType.EchoFang:
                return new EchoFang(data);
            case PassiveType.Spellweaver:
                return new Spellweaver(data);
            case PassiveType.IronRhythm:
                return new IronRhythm(data);
            case PassiveType.Heartcleaver:
                return new Heartcleaver(data);
            case PassiveType.KillersEdge:
                return new KillersEdge(data);
            case PassiveType.FortifiedHeart:
                return new FortifiedHeart(data);
            case PassiveType.BerserkersTempo:
                return new BerserkersTempo(data);
            case PassiveType.SoothingLight:
                return new SoothingLight(data);
            case PassiveType.SerratedStrikes:
                return new SerratedStrikes(data);
            case PassiveType.PoisonHits:
                return new PoisonHits(data);
            case PassiveType.BloodFeast:
                return new BloodFeast(data);
            case PassiveType.SecondWind:
                return new SecondWind(data);
            case PassiveType.RotBurst:
                return new RotBurst(data);
            case PassiveType.Unyielding:
                return new Unyielding(data);
            case PassiveType.OpeningGambit:
                return new OpeningGambit(data);
            case PassiveType.ThornGuard:
                return new ThornGuard(data);
            case PassiveType.BerserkersFrenzy:
                return new BerserkersFrenzy(data);
            case PassiveType.Shockwave:
                return new Shockwave(data);
            case PassiveType.FirstAidEnemy:
                return new FirstAidEnemy(data);
            case PassiveType.SurgeEcho:
                return new SurgeEcho(data); 
            case PassiveType.RallyingWinds:
                return new RallyingWinds(data);
            case PassiveType.LingeringCurse:
                return new LingeringCurse(data);
            case PassiveType.VitalWrath:
                return new VitalWrath(data);
            case PassiveType.ArcanizedSteel:
                return new ArcanizedSteel(data);
            case PassiveType.WoundingBlows:
                return new WoundingBlows(data);
            case PassiveType.VoidFang:
                return new VoidFang(data);
            case PassiveType.BloodFrenzy:
                return new BloodFrenzy(data);
            case PassiveType.RecklessFury:
                return new RecklessFury(data);
            case PassiveType.CullingInstinct:
                return new CullingInstinct(data);
            case PassiveType.WeakenedResolve:
                return new WeakenedResolve(data);
            case PassiveType.ArcaneBattery:
                return new ArcaneBattery(data);
            case PassiveType.MarkOfAgony:
                return new MarkOfAgony(data);
            case PassiveType.PredatorsHunger:
                return new PredatorsHunger(data);
            case PassiveType.PainResponse:
                return new PainResponse(data);
            case PassiveType.StoicBarrier:
                return new StoicBarrier(data);
            case PassiveType.GamblersEdge:
                return new GamblersEdge(data);
            default:
                UnityEngine.Debug.LogWarning("Unknown passive type: " + data.type);
                return null;
        }
    }
}
