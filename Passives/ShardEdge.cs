using UnityEngine;

public class ShardEdge : Passive
{
    
    public ShardEdge():base("Shard Edge","Basic attacks deal +20% damage"){}

    public override void ApplyEffect(Fighter fighter)
    {
        fighter.attackDamage = Mathf.RoundToInt(fighter.attackDamage*1.2f);
    }
}
