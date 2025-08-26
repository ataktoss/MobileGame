using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillShop : MonoBehaviour
{
    //public List<ItemData> itemsToFill;
    public ItemDatabase itemDatabase;
    public ItemDatabase bossItemDatabase;
    public List<Button> getItemButtons;
    public List<Image> itemIcons;
    public List<TMP_Text> itemNames;
    public List<TMP_Text> itemDescriptions;

    private int numberOfItemsInShop = 8;

    public void FillShopWithItems()
    {
        // Clear existing items



        // Get random items from the database
        List<ItemData> allItems = itemDatabase.GetRandomItems(numberOfItemsInShop);
        List<ItemData> bossItems = bossItemDatabase.GetRandomItems(1);
        
        for (int i = 0; i < numberOfItemsInShop; i++)
        {
            int index = i;
            List<ItemData> currentList = new();
            if (index == 0)
            {
                currentList = bossItems;
            }
            else
            {
                currentList = allItems;
            }

            getItemButtons[index].onClick.RemoveAllListeners();
            getItemButtons[index].onClick.AddListener(() => OnGetItemButtonClicked(currentList[index]));

            itemNames[index].text = currentList[index].itemName;
            itemDescriptions[index].text = currentList[index].description;
        }
        
    }


    public void OnGetItemButtonClicked(ItemData item)
    {
        //CHOSE THE HERO THAT GETS THE ITEM

        //REMOVE GOLD FROM PLAYER
        //ADD ITEM TO HERO
        Debug.Log($"Item {item.itemName} has been selected.");
        if (CombatManager.Instance.SpendGold(item.shopCost))
        {
            CombatRewards.Instance.BeginSelectHeroForItem(item);
            
        }
        else
        {
            Debug.Log("Not enough gold to purchase this item.");
        }
        
        

    }
    
    




}
