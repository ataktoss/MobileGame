using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillShop : MonoBehaviour
{
    //public List<ItemData> itemsToFill;
    public ItemDatabase itemDatabase;
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
        for (int i = 0; i < numberOfItemsInShop; i++)
        {
            //POSSIBLE IF STATEMENT FOR EXAMPLE IF EPIC ITEM THEN SHOW EPIC BORDER

            getItemButtons[i].onClick.AddListener(() => OnGetItemButtonClicked(allItems[i]));
            //itemIcons[i].sprite = allItems[i].icon;
            itemNames[i].text = allItems[i].itemName;
            itemDescriptions[i].text = allItems[i].description;

        }
    }


    public void OnGetItemButtonClicked(ItemData item)
    {
        //CHOSE THE HERO THAT GETS THE ITEM
        //REMOVE GOLD FROM PLAYER
        //ADD ITEM TO HERO

    }
    
    




}
