using UnityEngine;

public class Monster : MonoBehaviour, IFighter
{
    
    public string monsterName;
    public int life;
    public int mana;
    
    public void TakeDamage(int amount){
        life -= amount;
        Debug.Log(monsterName + "Took " + amount + " damage");
    }
    public void Attack(IFighter target,int damage){
        target.TakeDamage(damage);
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
