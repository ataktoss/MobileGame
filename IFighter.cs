using UnityEngine;

public interface IFighter
{
    
    


    void TakeDamage(int amount);
    void Attack(IFighter target, int damage);


}
