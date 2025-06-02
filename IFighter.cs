using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public enum FighterType
{
    Assassin,
    Mage,
    Fighter,
    Tank,
    Support
}

public class Fighter : MonoBehaviour
{

    public string unitName;
    public int baseLife;
    public int life;
    public int _currentLife;
    public int mana;
    public float baseAttackSpeed;
    public float attackSpeed;

    public int attackRange;
    public float movementSpeed = 5f;
    public int attackDamage;
    public int spellPower = 0;
    public int numberOfAttacks = 0;
    public int _currentMana = 0;
    public float critChance = 0.05f;
    public float critDamage = 2f;
    public int manaGainedFromHits = 5;
    public int currentXP = 0;

    //STATS AFTER ITEM APPLICATIONS

    public float TotalAttackSpeed => attackSpeed * (1 + equipedItems.Sum(item => item.bonusAttackSpeed));
    public int TotalSpellPower => spellPower + equipedItems.Sum(item => item.bonusSpellPower);
    public int TotalLife => baseLife + equipedItems.Sum(item => item.bonusLife);


    private float lastEffectTick;

    public bool melee;
    public bool isAlive = true;
    public bool isAttacking = false;
    public bool isFrozen = false;
    public bool isSilenced = false;
    private bool _isProcessingManaChange = false;
    public Spell fighterSpell;
    public Fighter currentTarget;
    public FighterType fighterType;
    public List<Passive> passives = new List<Passive>();
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    //DAMAGE TAKEN MODIFIER
    public List<Func<int, int>> damageModifiers = new List<Func<int, int>>();
    //DAMAGE DONE MODIFIER
    public List<Func<int, int>> outgoingDamageModifiers = new List<Func<int, int>>();
    public List<ItemData> equipedItems = new List<ItemData>();


    //Events
    public event Action<int> OnHealthChanged;
    public event Action<int> OnManaChanged;
    public event Action OnAttackPerformed;
    public event Action<int> OnTakeDamage;
    public event Action<int> OnSpellCast;
    //public event Action<int> OnCrit;
    public event Action OnDeath;





    private Coroutine attackCoroutine;


    public void TakeDamage(int amount)
    {

        if (this.gameObject != null)
        {

            foreach (var mod in damageModifiers)
            {
                amount = mod.Invoke(amount);
            }
            //Debug.Log("I AM TAKING DAMAGE CURRENT LIFE : " + _currentLife);
            _currentLife -= amount;
            //Debug.Log("NOW MY LIFE IS : " + _currentLife);
            //Debug.Log(unitName + " took " + amount + " damage!" + "Now life is : " + _currentLife);

            // ✨ Fire events
            OnHealthChanged?.Invoke(_currentLife);
            OnTakeDamage?.Invoke(amount);

            foreach (var passive in passives)
            {
                passive.OnTakeDamage(this, amount); // <- tell passives
            }
            if (_currentLife <= 0)
            {
                OnDeath?.Invoke();
                foreach (var passive in passives)
                {
                    passive.OnDeath(this); // <- tell passives
                }
                Debug.Log(unitName + " has died!" + "by taking damage of " + amount);
                isAlive = false;
                isAttacking = false;
                StopAllCoroutines();
                this.enabled = false;
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




    public void StartAttack(Fighter target)
    {
        currentTarget = target;
        if (!isAttacking)
        {
            isAttacking = true;
            attackCoroutine = StartCoroutine(AttackRoutine());
        }
    }



    public void StopAttack()
    {
        if (isAttacking)
        {
            isAttacking = false;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(TotalAttackSpeed);
            //Debug.Log("My attack speed is : " + TotalAttackSpeed + "NAME OF UNIT: " + this.unitName);
            if (currentTarget != null)
            {
                Attack(currentTarget, attackDamage);
            }

        }


    }



    public void Attack(Fighter target, int damage)
    {
        Debug.Log("" + unitName + " attacked " + target.unitName + " for " + damage + " damage! BEFORE DAMAGE MODIFIERS");
        if (isFrozen) return;
        bool isCrit = UnityEngine.Random.value < critChance;
        int finalDamage = damage;
        if (isCrit)
        {
            finalDamage = (int)(damage * critDamage);
            Debug.Log("CRITICAL HIT!");
        }
        foreach (var mod in outgoingDamageModifiers)
        {
            finalDamage = mod(finalDamage);
        }

        target.TakeDamage(finalDamage);
        Debug.Log("" + unitName + " attacked " + target.unitName + " for " + finalDamage + " damage!");
        Debug.Log(unitName + "current damage is : " + attackDamage);
        ChangeMana(manaGainedFromHits);
        //Debug.Log(unitName + " attacked for " + damage + " damage!" );

        // ✨ Fire event
        OnAttackPerformed?.Invoke();



        foreach (var passive in passives)
        {
            passive.OnAttack(this, target, damage); // <- tell passives
        }



    }

    public virtual void CastSpell(Spell spell, Fighter target)
    {
        if (isFrozen) return;
        if (isSilenced) return;

        spell.ApplyEffect(this, target, TotalSpellPower);
        OnSpellCast?.Invoke(spell.manaCost);
    }

    public void ChangeMana(int amount)
    {
        if (isSilenced || _isProcessingManaChange) return;
        _isProcessingManaChange = true;
        _currentMana += amount;
        //Debug.Log(this.name + " mana changed by " + amount + "! New mana: " + _currentMana);

        // Mana Event
        OnManaChanged?.Invoke(_currentMana);
        if (fighterSpell != null && _currentMana >= fighterSpell.manaCost)
        {
            _currentMana -= fighterSpell.manaCost;
            CastSpell(fighterSpell, currentTarget);
        }
        _isProcessingManaChange = false;

    }

    public void CustomEffect(Action theMethod)
    {
        theMethod();
    }

    public void Heal(int amount)
    {
        if ((_currentLife + amount) > TotalLife)
        {
            _currentLife = TotalLife;
        }
        else
        {
            _currentLife += amount;
        }


    }

    public void AddPassive(Passive newPassive)
    {
        passives.Add(newPassive);

        Debug.Log($"{unitName} gained passive: {newPassive.passiveName}");
        Debug.Log("Attack speed is now : " + attackSpeed);
        Debug.Log("THIS UNIT NOW HAS " + passives.Count + " PASSIVES");
    }

    // BUFFS KAI DEBUFFS HERE
    public void ApplyDebuff(StatusEffect effect)
    {
        activeEffects.Add(effect);
        effect.OnAPply(this);

    }

    public void ProcessStatusEffects()
    {

    }

    public void TickStatusEffects()
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            StatusEffect effect = activeEffects[i];
            effect.TryTick(this);
            if (effect.duration <= 0)
            {
                effect.OnExpire(this);
                activeEffects.RemoveAt(i);
            }
        }
    }

    // public void RemoveBuff(System.Type effectType){
    //     for(int i = activeEffects.Count-1; i>=0; i--){
    //         StatusEffect activeEffect = activeEffects[i];
    //         if(activeEffect.GetType()==effectType){
    //             activeEffect.OnExpire(this);
    //             activeEffects.RemoveAt(i);
    //             break;
    //         }
    //     }
    // }
    //BUFFS AND DEBUFFS ARE ONE
    public void RemoveBuff<T>() where T : StatusEffect
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            if (activeEffects[i] is T)
            {
                activeEffects[i].OnExpire(this);
                activeEffects.RemoveAt(i);
                break;
            }
        }
    }

    public void enableAllPassives()
    {
        for (int i = passives.Count - 1; i >= 0; i--)
        {
            passives[i].ApplyEffect(this);
            Debug.Log("Enabling passive: " + passives[i].passiveName + " for fighter: ✅" + unitName);
        }
    }

    public void EquipItem(ItemData item)
    {
        equipedItems.Add(item);
    }
    public void UnequipItem(ItemData item)
    {
        equipedItems.Remove(item);
    }

    public void LevelUp()
    {





        life += Mathf.RoundToInt(life * 0.1f);
        Debug.Log(unitName + " just leveled up! New life: " + life);
        attackDamage += Mathf.RoundToInt(attackDamage * 0.1f);
        attackSpeed += attackSpeed * 0.1f;


        //GENERATE PASSIVE CHOICE

    }

    public void SetStatsFromType(FighterType type)
    {
        
        fighterType = type;
        switch (type)
        {
            case FighterType.Assassin:
                critChance += 0.1f; 
                break;
            case FighterType.Mage:
                manaGainedFromHits += 5;
                break;
            case FighterType.Fighter:
                AddPassive(new LeechingBlows(0.1f));
                break;
            case FighterType.Tank:
                // Reduced damage taken buffby some sort
                break;
            case FighterType.Support:
                AddPassive(new FirstAid());
                break;
        }
        
    }
    public void MoveToward(Vector3 targetPosition)
    {
        if (isFrozen) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    //EZ access from other scripts
    public int GetCurrentLife() => _currentLife;
    public int GetCurrentMana() => _currentMana;


    public void PrepareForCombat()
    {
        attackSpeed = baseAttackSpeed;
        life = TotalLife; // BASE LIFE + ITEMS
        SetStatsFromType(fighterType);
        enableAllPassives();
        _currentLife = life;
        _currentMana = mana;
        isAlive = true;
        isAttacking = false;
        isFrozen = false;
        isSilenced = false;
        numberOfAttacks = 0;
        outgoingDamageModifiers.Clear();
        damageModifiers.Clear();
        activeEffects.Clear();

        Debug.Log($"{unitName} is prepared for combat with {TotalLife} life and {mana} mana.");
    }

    public void Start()
    {
        PrepareForCombat();
        Debug.Log($"{unitName} just used the Start Function");


    }








}
