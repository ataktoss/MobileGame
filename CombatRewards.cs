using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CombatRewards : MonoBehaviour
{

    //public Button getHeroButton;
    public static CombatRewards Instance { get; private set; }
    public Button getItemButton;
    public Button getHeroButton;

    public Button itemRewardButton1, itemRewardButton2, itemRewardButton3;
    public Button heroRewardButton1, heroRewardButton2, heroRewardButton3;
    //public GameObject rewardObject1,rewardObject2,rewardObject3;
    public TMP_Text itemName1, itemName2, itemName3;
    public TMP_Text itemText1, itemText2, itemText3;
    public TMP_Text heroName1, heroName2, heroName3;
    public ItemDatabase itemDatabase;
    public HeroDatabase heroDatabase;

    public ItemData itemReward1, itemReward2, itemReward3;
    public GameObject heroReward1, heroReward2, heroReward3;

    public GameObject itemContainer1, itemContainer2, itemContainer3;
    public GameObject heroContainer1, heroContainer2, heroContainer3;

    public GameObject itemHero1, itemHero2, itemHero3;
    public Button giveItemHero1, giveItemHero2, giveItemHero3;
    public TMP_Text giveItemHero1Text, giveItemHero2Text, giveItemHero3Text;
    //PASSIVE REWARDS
    public List<TMP_Text> passiveRewardNames;
    public List<GameObject> passiveRewardContainers;
    public List<Button> choosePassiveRewardButtons;

    private ItemData pendingItemReward;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }


    void Start()
    {

        getItemButton.onClick.AddListener(generateItemRewards);
        getHeroButton.onClick.AddListener(generateHeroReward);

        //ADD LISTENER FOR ON CLICK BUTTON TO PASS ITEM REF
        itemRewardButton1.onClick.AddListener(() => SelectItem(itemReward1));
        itemRewardButton2.onClick.AddListener(() => SelectItem(itemReward2));
        itemRewardButton3.onClick.AddListener(() => SelectItem(itemReward3));
        //HERO REWARD BUTTONS
        heroRewardButton1.onClick.AddListener(() => SelectHero(heroReward1));
        heroRewardButton2.onClick.AddListener(() => SelectHero(heroReward2));
        heroRewardButton3.onClick.AddListener(() => SelectHero(heroReward3));

        giveItemHero1.onClick.AddListener(() => SelectHeroForItem(1));
        giveItemHero2.onClick.AddListener(() => SelectHeroForItem(2));
        giveItemHero3.onClick.AddListener(() => SelectHeroForItem(3));


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void choseReward()
    {
        getItemButton.gameObject.SetActive(true);
        getHeroButton.gameObject.SetActive(true);

    }

    public void generateItemRewards()
    {
        getItemButton.gameObject.SetActive(false);
        getHeroButton.gameObject.SetActive(false);
        itemContainer1.SetActive(true);
        itemContainer2.SetActive(true);
        itemContainer3.SetActive(true);
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
        getItemButton.gameObject.SetActive(false);
        getHeroButton.gameObject.SetActive(false);
        heroContainer1.SetActive(true);
        heroContainer2.SetActive(true);
        heroContainer3.SetActive(true);
        heroReward1 = heroDatabase.GetRandomHero();
        heroReward2 = heroDatabase.GetRandomHero();
        heroReward3 = heroDatabase.GetRandomHero();
        heroName1.text = heroReward1.GetComponent<Fighter>().unitName;
        heroName2.text = heroReward2.GetComponent<Fighter>().unitName;
        heroName3.text = heroReward3.GetComponent<Fighter>().unitName;

    }

    // public void GeneratePassiveRewards(int whichHero)
    // {
    //     for (int i = 0; i < 3; i++)
    //     {
    //         Passive passiveData = PassiveManager.Instance.GetRandomPassive();
    //         if (passiveData == null) continue; // Check if passiveData is null
    //         passiveRewardContainers[i].SetActive(true);
    //         passiveRewardNames[i].text = passiveData.passiveName;
    //         choosePassiveRewardButtons[i].onClick.RemoveAllListeners();
    //         choosePassiveRewardButtons[i].onClick.AddListener(() => SelectPassiveReward(passiveData, whichHero));
    //     }


    // }

    public void SelectPassiveReward(Passive passive, int whichHero)
    {

        CombatManager.Instance.GivePassive(whichHero, passive);
        GameManager.Instance.ChangeState(GameManager.GameState.combatReward);
        passiveRewardContainers.ForEach(container => container.SetActive(false));
    }

    public void SelectItem(ItemData item)
    {

        itemContainer1.SetActive(false);
        itemContainer2.SetActive(false);
        itemContainer3.SetActive(false);
        // CombatManager.Instance.currentTeam[0].equippedItems.Add(item);
        // GameManager.Instance.ChangeState(GameManager.GameState.PickingNode);
        itemHero1.SetActive(true);
        itemHero2.SetActive(true);
        itemHero3.SetActive(true);
        pendingItemReward = item;
        Debug.Log("Adde the item :" + item.itemName);
    }

    public void SelectHeroForItem(int heroNumber)
    {
        switch (heroNumber)
        {
            case 1:
                CombatManager.Instance.currentTeam[0].equippedItems.Add(pendingItemReward);

                break;
            case 2:
                CombatManager.Instance.currentTeam[1].equippedItems.Add(pendingItemReward);

                break;
            case 3:
                CombatManager.Instance.currentTeam[2].equippedItems.Add(pendingItemReward);

                break;
        }
        itemHero1.SetActive(false);
        itemHero2.SetActive(false);
        itemHero3.SetActive(false);
        GameManager.Instance.ChangeState(GameManager.GameState.PickingNode);

    }


    public void SelectHero(GameObject gameObject)
    {
        //HIDE CHOSE HERO BUTTONS
        heroContainer1.SetActive(false);
        heroContainer2.SetActive(false);
        heroContainer3.SetActive(false);
        Debug.Log("Selecting the hero " + gameObject.name);
        CombatManager.Instance.AddHero(gameObject);
        GameManager.Instance.ChangeState(GameManager.GameState.PickingNode);
    }

    public void BeginSelectHeroForItem(ItemData item)
    {
        pendingItemReward = item;
        itemHero1.SetActive(true);
        itemHero2.SetActive(true);
        itemHero3.SetActive(true);
        itemContainer1.SetActive(false);
        itemContainer2.SetActive(false);
        itemContainer3.SetActive(false);  
    }

}
