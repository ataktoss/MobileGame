using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFighter : MonoBehaviour
{
    
    public string unitName;
    public int life;
    public int mana;
    public int attackSpeed;
    public bool melee;
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




    public int _currentLife;
    private int _currentMana;
    private Coroutine attackCoroutine;


    public void TakeDamage(int amount){

        _currentLife -= amount;
        Debug.Log(unitName + " took " + amount + " damage!" + "Now life is : " + _currentLife);

        // ✨ Fire events
        OnHealthChanged?.Invoke(_currentLife);
        OnTakeDamage?.Invoke();

        foreach (var passive in passives)
        {
            passive.OnTakeDamage(this, amount); // <- tell passives
        }


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
            Attack(currentTarget,10);
        }


    }
    


    public void Attack(IFighter target, int damage)
    {
        target.TakeDamage(damage);
        Debug.Log(unitName + " attacked for " + damage + " damage!" );

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
        }
        
    }

    public void ChangeMana(int amount)
    {
        _currentMana += amount;
        Debug.Log(unitName + " mana changed by " + amount + "! New mana: " + _currentMana);

        // ✨ Fire event
        OnManaChanged?.Invoke(_currentMana);
        if(_currentMana >= fighterSpell.manaCost){
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


    //EZ access from other scripts
    public int GetCurrentLife() => _currentLife;
    public int GetCurrentMana() => _currentMana;



    public void Start()
    {
        _currentLife = life;
    }








}
