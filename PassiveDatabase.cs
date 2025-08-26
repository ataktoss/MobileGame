using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PassiveDatabase", menuName = "RPG/Passive Database")]
public class PassiveDatabase : ScriptableObject
{
    public List<PassiveData> allPassives;


    public PassiveData GetRandomPassive()
    {
        if (allPassives.Count == 0) return null;
        return allPassives[Random.Range(0, allPassives.Count)];
    }

    public List<PassiveData> GetRandomPassives(int count)
    {
        List<PassiveData> pool = new(allPassives);
        List<PassiveData> result = new();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            result.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return result;
    }

}
