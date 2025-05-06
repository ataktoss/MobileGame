using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IFighter : MonoBehaviour
{
    
    public string unitName;
    public int life;
    public int mana;
    public float attackSpeed;
    public int _currentLife;
    public int attackRange;
    public float movementSpeed= 5f;
    public int attackDamage;
    private int _currentMana = 0;
    private float lastEffectTick;
    
    public bool melee;
    public bool isAlive = true;
    public bool isAttacking = false;
    public Spell fighterSpell;
    public IFighter currentTarget;
    public List<Passive> passives = new List<Passive>();
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    
    //Events
    public event Action<int> OnHealthChanged;
    public event Action<int> OnManaChanged;
    public event Action OnAttackPerformed;
    public event Action OnTakeDamage;

    


    
    private Coroutine attackCoroutine;


    public void TakeDamage(int amount){

        if(this.gameObject != null){
            _currentLife -= amount;
        //Debug.Log(unitName + " took " + amount + " damage!" + "Now life is : " + _currentLife);

       

        // ✨ Fire events
        OnHealthChanged?.Invoke(_currentLife);
        OnTakeDamage?.Invoke();

        foreach (var passive in passives)
        {
            passive.OnTakeDamage(this, amount); // <- tell passives
        }
        if(_currentLife <= 0){
            isAlive = false;
            isAttacking = false;
            StopAllCoroutines();
            this.enabled=false;
            Destroy(this.gameObject);
        }


        }
        
        

    }

    public void Die()
    {
        if (!isAlive) return; // prevent double death

        isAlive = false;
        StopAllCoroutines(); // optional if you're running anything

        // Disable behavior
        this.enabled = false;
        Destroy(this.gameObject);

        // Optionally disable visuals/collider/etc.
        //GetComponent<Collider2D>()?.enabled = false;

        // Play death animation or delay actual destruction
        StartCoroutine(DelayedDeath());
    }
    IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(0.5f); // time for death animation if needed
        Destroy(gameObject);
    }




    public void StartAttack(IFighter target){
        currentTarget = target;
        if(!isAttacking){
            isAttacking = true;
            attackCoroutine  = StartCoroutine(AttackRoutine());
        }
    }
    


    public void StopAttack(){
        if (isAttacking){
            isAttacking = false;
            if(attackCoroutine != null){
                StopCoroutine(attackCoroutine);
            }
        }
    }

    private IEnumerator AttackRoutine(){
        while(isAttacking){
            yield return new WaitForSeconds(attackSpeed);
            if(currentTarget != null){
                Attack(currentTarget,attackDamage);
            }
            
        }


    }
    


    public void Attack(IFighter target, int damage)
    {
        target.TakeDamage(damage);
        ChangeMana(5);
        //Debug.Log(unitName + " attacked for " + damage + " damage!" );

        // ✨ Fire event
        OnAttackPerformed?.Invoke();

        

        foreach (var passive in passives)
        {
            passive.OnAttack(this, target, damage); // <- tell passives
        }

        

    }

    public virtual void CastSpell(Spell spell, IFighter target){
        if(_currentMana >= spell.manaCost){
            _currentMana -= spell.manaCost;
            
            spell.ApplyEffect(this,target);
            Debug.Log(this.name + "Casted the spell : " + spell.name + " Now mana is : " + _currentMana);
        }
        
    }

    public void ChangeMana(int amount)
    {
        _currentMana += amount;
        Debug.Log(this.name + " mana changed by " + amount + "! New mana: " + _currentMana);

        // ✨ Fire event
        OnManaChanged?.Invoke(_currentMana);
        if(fighterSpell!=null &&  _currentMana >= fighterSpell.manaCost){
            CastSpell(fighterSpell,currentTarget);
        }


    }

    public void CustomEffect(Action theMethod){
        theMethod();
    }
    
    public void Heal (int amount){
        _currentLife += amount;
    }

    public void AddPassive(Passive newPassive)
    {
        passives.Add(newPassive);
        
        Debug.Log($"{unitName} gained passive: {newPassive.passiveName}");
    }

    public void ApplyDebuff(StatusEffect effect){
        activeEffects.Add(effect);
        effect.OnAPply(this);
        
    }

    public void ProcessStatusEffects(){
        
    }

    public void TickStatusEffects(){
        for(int i = activeEffects.Count -1; i>= 0; i--){
            StatusEffect effect = activeEffects[i];
            effect.TryTick(this);
            if(effect.duration<= 0){
                effect.OnExpire(this);
                activeEffects.RemoveAt(i);
            }
        }
    }


    public void MoveToward(Vector3 targetPosition){
        transform.position = Vector3.MoveTowards(transform.position,targetPosition,movementSpeed*Time.deltaTime);
    }

    //EZ access from other scripts
    public int GetCurrentLife() => _currentLife;
    public int GetCurrentMana() => _currentMana;



    public void Start()
    {
        _currentLife = life;

        
    }








}
