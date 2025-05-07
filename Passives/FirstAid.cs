using UnityEngine;

public class FirstAid: Passive,IEffect
{
    
    public FirstAid():base("First Aid","Heal lowest health ally for 10 every 5 seconds"){}

    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        fighter.ApplyDebuff(new FirstAidBuff(10,200,7));
    }

    

}
