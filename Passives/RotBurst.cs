using UnityEngine;

public class RotBurst : Passive, IEffect
{
    //Explode on death dealing 15% of life to all enemies

    public RotBurst(PassiveData data):base(data){
        
    }



    public override void OnAttack(Fighter fighter, Fighter target, int damage)
    {
        
    }

    public override void OnSpellCast(Fighter fighter, int manaCost)
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
            
            if(aliveHero.isAlive &&  aliveHero!= null){
                aliveHero.TakeDamage(Mathf.RoundToInt(aliveHero.TotalLife*0.15f),fighter);
                
            }
            
        }
    }
}
