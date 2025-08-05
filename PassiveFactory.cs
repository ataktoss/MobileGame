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
            
            default:
                UnityEngine.Debug.LogWarning("Unknown passive type: " + data.type);
                return null;
        }
    }
}
