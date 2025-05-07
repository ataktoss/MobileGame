using UnityEngine;

public class ShardEdge : Passive
{
    
    public ShardEdge():base("Shard Edge","Basic attacks deal +20% damage"){}

    public override void ApplyEffect(IFighter fighter)
    {
        fighter.attackDamage = Mathf.RoundToInt(fighter.attackDamage*1.2f);
    }
}
