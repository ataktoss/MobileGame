using UnityEngine;

public static class PassiveFactory
{
    public static Passive Create(PassiveData data)
    {
        switch (data.passiveId)
        {
            case "ArcaneFlow":
                return new ArcaneFlow();
            case "QuickHands":
                return new QuickHands();
            default:
                Debug.LogWarning($"Unknown passive ID: {data.passiveId}");
                return null;
        }
    }
}
