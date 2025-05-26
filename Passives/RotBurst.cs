using UnityEngine;

public class RotBurst : Passive, IEffect
{
    public int explodeAmount;

    public RotBurst(int explodeAmount):base("RotBurst","Explode on Death"){
        this.explodeAmount = explodeAmount;
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
    {
        
    }

    public override void OnTakeDamage(Fighter fighter, int damage)
    {
        
    }


    public void Apply(Fighter caster, Fighter target)
    {
        
    }

    public override void ApplyEffect(Fighter fighter)
    {
        
    }
    public override void OnDeath(Fighter fighter)
    {
        foreach(Fighter aliveHero in CombatManager.Instance.GetHeroList()){
            Debug.Log("Got HERO LIST READY TO EXPLODE");
            if(aliveHero.isAlive){
                aliveHero.TakeDamage(explodeAmount);
                Debug.Log("Exploded on : " + aliveHero.name + " For damage : " + explodeAmount);
            }
            
        }
    }
}
