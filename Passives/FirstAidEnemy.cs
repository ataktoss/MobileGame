using UnityEngine;

public class FirstAidEnemy: Passive,IEffect
{
    
    //public FirstAid():base("First Aid","Heal lowest health ally for 10 every 5 seconds"){}
    public FirstAidEnemy(PassiveData data) : base(data) { }
    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        fighter.ApplyDebuff(new FirstAidEnemyBuff(10,200,3));
    }

    

}
