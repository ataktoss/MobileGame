using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Items/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> allItems;


    public ItemData GetRandomItem(){
        if(allItems.Count == 0) return null;
        return allItems[Random.Range(0,allItems.Count)];
    }

    public List<ItemData> GetRandomItems(int count){
        List<ItemData> pool = new(allItems);
        List<ItemData> result = new();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            result.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return result;
    }

}
