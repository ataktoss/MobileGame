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
    public int shield;
    public int mana;
    public float baseAttackSpeed;
    public float attackSpeed;

    public int attackRange;
    public float movementSpeed = 5f;
    public int baseAttackDamage;
    public int attackDamage;

    //Default spellPower 0 kai aplos pernei added apo items + spells + alla chars. Reset on combat start
    public int spellPower = 0;
    public int numberOfAttacks = 0;
    public int _currentMana = 0;
    public float basecritChance = 0.05f;
    public float critChance = 0.05f;
    public float basecritDamage = 2f;
    public float critDamage = 2f;
    public int manaGainedFromHits = 5;
    public int currentXP = 0;

    //STATS AFTER ITEM APPLICATIONS

    public float TotalAttackSpeed => attackSpeed / (1 + equipedItems.Sum(item => item.bonusAttackSpeed));
    public int TotalSpellPower => spellPower + equipedItems.Sum(item => item.bonusSpellPower);
    public int TotalLife => baseLife + equipedItems.Sum(item => item.bonusLife);
    public float TotalCriticalChance => critChance + equipedItems.Sum(item => item.bonusCriticalChance);
    public float TotalCriticalDamage => critDamage + equipedItems.Sum(item => item.bonusCriticalDamage);
    public int TotalAttackDamage => attackDamage + equipedItems.Sum(item => item.bonusAttackDamage);

    private float lastEffectTick;

    public bool melee;
    public bool isAlive = true;
    public bool isAttacking = false;
    public bool currentlyAttacking = false;
    public bool isFrozen = false;
    public bool isSilenced = false;
    private bool _isProcessingManaChange = false;
    public Spell fighterSpell;
    public Fighter currentTarget;
    public FighterType fighterType;

    public List<Passive> passives = new List<Passive>();
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    //DAMAGE TAKEN MODIFIER
    public List<Func<int, int>> damageTakenModifiers = new List<Func<int, int>>();
    //DAMAGE DONE MODIFIER
    public List<Func<int, int>> damageDoneModifiers = new List<Func<int, int>>();
    public List<ItemData> equipedItems = new List<ItemData>();
    public List<ItemEffect> itemEffects = new List<ItemEffect>();

    //Events
    public event Action<int> OnHealthChanged;
    public event Action<int> OnManaChanged;
    public event Action OnAttackPerformed;
    //public event Action ModifyDamageTaken;
    public event Action<int> OnTakeDamage;
    public event Action<int> OnSpellCast;
    //public event Action<int> OnCrit;
    public event Action OnDeath;
    public ParticleSystem spellEffect;




    private Coroutine attackCoroutine;


    public void TakeDamage(int amount, Fighter attacker)
    {

        if (this.gameObject != null)
        {

            foreach (var mod in damageTakenModifiers)
            {
                amount = mod.Invoke(amount);
            }
            foreach (var passive in passives)
            {
                amount = passive.ModifyDamageTaken(this, amount); // <- tell passives
            }

            _currentLife -= amount;
            CombatManager.Instance.RegisterDamage(attacker, amount);
            //Debug.Log($"{unitName} took {amount} damage! from {attacker.unitName}");

            OnHealthChanged?.Invoke(_currentLife);
            OnTakeDamage?.Invoke(amount);

            foreach (var passive in passives)
            {
                passive.OnTakeDamage(this, attacker, amount); // <- tell passives
            }
            if (_currentLife <= 0)
            {
                OnDeath?.Invoke();
                foreach (var passive in passives)
                {
                    passive.OnDeath(this); // <- tell passives
                }
                Die();
            }
        }
    }

    public void Die()
    {
        //Debug.Log(unitName + " has died!");
        isAlive = false;
        isAttacking = false;
        this.enabled = false;
        StopAllCoroutines();
        Destroy(this.gameObject);
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
        float timer = 0f;
        while (isAttacking)
        {
            timer += Time.deltaTime;
            if (timer >= 1f / TotalAttackSpeed)
            {
                timer = 0f;
                // Attack the target
                if (currentTarget != null)
                {
                    Attack(currentTarget, TotalAttackDamage);
                }
            }

            yield return null;

        }


    }



    public void Attack(Fighter target, int damage)
    {
        if (currentlyAttacking) return;
        currentlyAttacking = true;
        try
        {
            if (isFrozen) return;

            if (fighterSpell != null && _currentMana >= fighterSpell.manaCost)
            {
                ChangeMana(-fighterSpell.manaCost);
                CastSpell(fighterSpell, currentTarget);
            }

            bool isCrit = UnityEngine.Random.value < TotalCriticalChance;
            int finalDamage = damage;
            if (isCrit)
            {
                finalDamage = (int)(damage * TotalCriticalDamage);
                //Debug.Log("CRITICAL HIT!");
            }

            foreach (var passive in passives)
            {
                finalDamage = passive.ModifyDamageDone(this, currentTarget, finalDamage);
                if (isCrit)
                {
                    passive.OnCrit(this, target, finalDamage, isCrit);
                }
            }
            foreach (var mod in damageDoneModifiers)
            {
                finalDamage = mod(finalDamage);
            }


            OnAttackPerformed?.Invoke();



            foreach (var passive in passives)
            {
                passive.OnAttack(this, target, damage); // <- tell passives
            }


            foreach (var itemEffect in itemEffects)
            {
                finalDamage = itemEffect.OnBeforeAttack(this, target, finalDamage, isCrit);
            }

            // ITEM BEFORE ATTACK HERE

            target.TakeDamage(finalDamage, this);
            //Debug.Log("" + unitName + " attacked " + target.unitName + " for " + finalDamage + " damage After damage mods");

            //ITEM AFTER ATTACK HERE
            foreach (var itemEffect in itemEffects)
            {
                itemEffect.OnAfterAttack(this, target, finalDamage, isCrit);
            }
            ChangeMana(manaGainedFromHits);
        }
        finally
        {
            currentlyAttacking = false;
        }



    }

    public virtual void CastSpell(Spell spell, Fighter target)
    {
        if (isFrozen) return;
        if (isSilenced) return;

        if (spellEffect != null)
        {
            spellEffect.Play();
        }
        Debug.Log($"{this.unitName} is casting {spell.name}");
        spell.ApplyEffect(this, target, TotalSpellPower);
        OnSpellCast?.Invoke(spell.manaCost);
        foreach (var itemEffect in itemEffects)
        {
            itemEffect.OnSpellCast(this, target, this.spellPower);
        }
        foreach (var passive in passives)
        {
            passive.OnSpellCast(this, spell.manaCost); // <- tell passives
        }
    }

    public void ChangeMana(int amount)
    {
        if (isSilenced || _isProcessingManaChange) return;
        _isProcessingManaChange = true;
        _currentMana += amount;
        //Debug.Log(this.name + " mana changed by " + amount + "! New mana: " + _currentMana);

        // Mana Event
        OnManaChanged?.Invoke(_currentMana);

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

    public void ChangeShield(int amount)
    {
        shield += amount;

    }

    public void AddPassive(Passive newPassive)
    {
        passives.Add(newPassive);

        foreach (var passive in passives)
        {
            Debug.Log("The hero :" + unitName + " has passive: " + passive.passiveName);
        }

        // Debug.Log($"{unitName} gained passive: {newPassive.passiveName}");
        // Debug.Log("Attack speed is now : " + attackSpeed);
        // Debug.Log("THIS UNIT NOW HAS " + passives.Count + " PASSIVES");
    }

    // BUFFS KAI DEBUFFS HERE
    public void ApplyDebuff(StatusEffect effect)
    {
        activeEffects.Add(effect);
        effect.OnApply(this);

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
            //Debug.Log("Enabling passive: " + passives[i].passiveName + " for fighter: ✅" + unitName);
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





        // life += Mathf.RoundToInt(life * 0.1f);
        // //Debug.Log(unitName + " just leveled up! New life: " + life);
        // attackDamage += Mathf.RoundToInt(attackDamage * 0.1f);
        // attackSpeed += attackSpeed * 0.1f;


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
                //manaGainedFromHits += 5;
                spellPower += 20;
                break;
            case FighterType.Fighter:
                //AddPassive(new LeechingBlows(0.1f));
                break;
            case FighterType.Tank:
                // Reduced damage taken buffby some sort
                break;
            case FighterType.Support:
                //AddPassive(new FirstAid());
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
        attackDamage = baseAttackDamage;
        attackSpeed = baseAttackSpeed;
        spellPower = 0;
        critChance = basecritChance;
        critDamage = basecritDamage;
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
        damageDoneModifiers.Clear();
        damageTakenModifiers.Clear();
        activeEffects.Clear();
        foreach (var item in equipedItems)
        {
            foreach (var itemEffect in item.itemEffects)
            {
                itemEffects.Add(itemEffect);
            }
        }

        //Debug.Log($"{unitName} is prepared for combat with {TotalLife} life and {mana} mana.");
    }

    public void Start()
    {
        //PrepareForCombat();
        //Debug.Log($"{unitName} just used the Start Function");


    }








}
