using Unity.VisualScripting;
using UnityEngine;

public class DebuffTest : MonoBehaviour,IEffect
{
    public int damagePerTurn;
    public int duration;
    public Fighter targetDummy;
    public Fighter targetDummy2;
    public Fighter targetDummy3;

    public void Start(){
        Apply(null,targetDummy);
        Apply(null,targetDummy2);
        Apply(null,targetDummy3);
    }

    public DebuffTest(int damagePerTurn, int duration){
        this.damagePerTurn = damagePerTurn;
        this.duration = duration;
    }
    
    public void Apply(Fighter caster,Fighter target ){
        target.ApplyDebuff(new CurseEffect(1.25f,5,1));
        
        
    }

    // void IEffect.Apply(IFighter caster, IFighter target)
    // {
    //     Apply(caster, target);
    // }
}
