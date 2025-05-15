using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CombatRewards : MonoBehaviour
{

    //public Button getHeroButton;
    public Button getItemButton;

    public Button itemRewardButton1, itemRewardButton2, itemRewardButton3;
    //public GameObject rewardObject1,rewardObject2,rewardObject3;
    public TMP_Text itemName1, itemName2, itemName3;
    public TMP_Text itemText1, itemText2, itemText3;
    public ItemDatabase itemDatabase;
    public HeroDatabase heroDatabase;

    public ItemData itemReward1, itemReward2, itemReward3;
    public GameObject heroReward1, heroReward2, heroReward3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getHeroButton.onClick.AddListener(generateHeroReward);
        getItemButton.onClick.AddListener(generateHeroReward);

        // ADD LISTENER FOR ON CLICK BUTTON TO PASS ITEM REF
        // itemRewardButton1.onClick.AddListener(() => SelectItem(itemReward1));
        // itemRewardButton2.onClick.AddListener(() => SelectItem(itemReward1));
        // itemRewardButton3.onClick.AddListener(() => SelectItem(itemReward1));

        itemRewardButton1.onClick.AddListener(() => SelectHero(heroReward1));
        itemRewardButton2.onClick.AddListener(() => SelectHero(heroReward2));
        itemRewardButton3.onClick.AddListener(() => SelectHero(heroReward3));


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void generateItemRewards()
    {

        itemReward1 = itemDatabase.GetRandomItem();
        itemReward2 = itemDatabase.GetRandomItem();
        itemReward3 = itemDatabase.GetRandomItem();
        itemName1.text = itemReward1.itemName;
        itemName2.text = itemReward2.itemName;
        itemName3.text = itemReward3.itemName;
        itemText1.text = itemReward1.description;
        itemText2.text = itemReward2.description;
        itemText3.text = itemReward3.description;



    }

    public void generateHeroReward()
    {
        heroReward1 = heroDatabase.GetRandomHero();
        heroReward2 = heroDatabase.GetRandomHero();
        heroReward3 = heroDatabase.GetRandomHero();
        itemName1.text = heroReward1.GetComponent<IFighter>().unitName;
        itemName2.text = heroReward2.GetComponent<IFighter>().unitName;
        itemName3.text = heroReward3.GetComponent<IFighter>().unitName;

    }



    public void SelectItem(ItemData item)
    {
        GameManager.Instance.AddItemToInventory(item);
    }

    public void SelectHero(GameObject gameObject)
    {
        Debug.Log("Selecting the hero " + gameObject.name);
        CombatManager.Instance.AddHero(gameObject);
    }

}
