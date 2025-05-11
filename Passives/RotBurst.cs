using UnityEngine;

public class RotBurst : Passive, IEffect
{
    public int explodeAmount;

    public RotBurst(int explodeAmount):base("RotBurst","Explode on Death"){
        this.explodeAmount = explodeAmount;
    }



    public override void OnAttack(IFighter fighter, IFighter target, int damage)
    {
        
    }

    public override void OnSpellCast(IFighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(IFighter fighter, int damage)
    {
        
    }


    public void Apply(IFighter caster, IFighter target)
    {
        
    }

    public override void ApplyEffect(IFighter fighter)
    {
        
    }
    public override void OnDeath(IFighter fighter)
    {
        foreach(IFighter aliveHero in CombatManager.Instance.GetHeroList()){
            Debug.Log("Got HERO LIST READY TO EXPLODE");
            if(aliveHero.isAlive){
                aliveHero.TakeDamage(explodeAmount);
                Debug.Log("Exploded on : " + aliveHero.name + " For damage : " + explodeAmount);
            }
            
        }
    }
}
