using UnityEngine;

public class FirstAid: Passive,IEffect
{
    
    //public FirstAid():base("First Aid","Heal lowest health ally for 10 every 5 seconds"){}
    public FirstAid(PassiveData data) : base(data) { }
    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        fighter.ApplyDebuff(new FirstAidBuff(10,200,4));
    }

    

}
