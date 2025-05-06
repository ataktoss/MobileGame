using Unity.VisualScripting;
using UnityEngine;

public class DebuffTest : MonoBehaviour,IEffect
{
    public int damagePerTurn;
    public int duration;
    public IFighter targetDummy;
    public IFighter targetDummy2;
    public IFighter targetDummy3;

    public void Start(){
        Apply(null,targetDummy);
        Apply(null,targetDummy2);
        Apply(null,targetDummy3);
    }

    public DebuffTest(int damagePerTurn, int duration){
        this.damagePerTurn = damagePerTurn;
        this.duration = duration;
    }
    
    public void Apply(IFighter caster,IFighter target ){
        target.ApplyDebuff(new SlowEffect(10,5,1));
        
        
    }

    // void IEffect.Apply(IFighter caster, IFighter target)
    // {
    //     Apply(caster, target);
    // }
}
