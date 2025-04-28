using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class Hero : MonoBehaviour, IFighter
{
    public string heroName;
    public int life;
    public int mana;
    public int attackSpeed;
    public bool melee;


    public List<Passive> passives = new List<Passive>(); 



    // 🔥 EVENTS 🔥
    public event Action<int> OnHealthChanged;
    public event Action<int> OnManaChanged;
    public event Action OnAttackPerformed;
    public event Action OnTakeDamage;

    private int _currentLife;
    private int _currentMana;

    private void Awake()
    {
        _currentLife = life;
        _currentMana = mana;
    }

    public void TakeDamage(int amount)
    {
        _currentLife -= amount;
        Debug.Log(heroName + " took " + amount + " damage!");

        // ✨ Fire events
        OnHealthChanged?.Invoke(_currentLife);
        OnTakeDamage?.Invoke();

        foreach(var passive in passives){
            passive.OnTakeDamage(this,amount);
        }

    }

    public void Attack(IFighter target, int damage)
    {
        target.TakeDamage(damage);
        Debug.Log(heroName + " attacked for " + damage + " damage!");

        // ✨ Fire event
        OnAttackPerformed?.Invoke();

        // Example: Gaining mana on attack
        ChangeMana(10);

        foreach (var passive in passives)
        {
            passive.OnAttack(this, target, damage); // <- tell passives
        }

    }


    public void ChangeMana(int amount)
    {
        _currentMana += amount;
        Debug.Log(heroName + " mana changed by " + amount + "! New mana: " + _currentMana);

        // ✨ Fire event
        OnManaChanged?.Invoke(_currentMana);
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
        Debug.Log($"{heroName} gained passive: {newPassive.passiveName}");
    }







    // 🔥 If you want access to the values from other scripts
    public int GetCurrentLife() => _currentLife;
    public int GetCurrentMana() => _currentMana;
}
