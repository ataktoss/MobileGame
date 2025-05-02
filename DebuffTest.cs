using Unity.VisualScripting;
using UnityEngine;

public class DebuffTest : MonoBehaviour,IEffect
{
    public int damagePerTurn;
    public int duration;
    public IFighter targetDummy;

    public void Start(){
        Apply(null,targetDummy);
    }

    public DebuffTest(int damagePerTurn, int duration){
        this.damagePerTurn = damagePerTurn;
        this.duration = duration;
    }
    
    public void Apply(IFighter caster,IFighter target ){
        target.ApplyDebuff(new BurnEffect(5,5));
    }

    // void IEffect.Apply(IFighter caster, IFighter target)
    // {
    //     Apply(caster, target);
    // }
}
