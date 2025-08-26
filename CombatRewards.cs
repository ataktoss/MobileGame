using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Can probably remove 50% of the code but works for now
public class CombatRewards : MonoBehaviour
{

    //public Button getHeroButton;
    public static CombatRewards Instance { get; private set; }
    public Button getItemButton;
    public Button getBossItemButton;
    public Button getHeroButton;

    public Button itemRewardButton1, itemRewardButton2, itemRewardButton3;
    public Button heroRewardButton1, heroRewardButton2, heroRewardButton3;
    //public GameObject rewardObject1,rewardObject2,rewardObject3;
    public TMP_Text itemName1, itemName2, itemName3;
    public TMP_Text itemText1, itemText2, itemText3;
    public TMP_Text heroName1, heroName2, heroName3;
    public ItemDatabase itemDatabase;
    public ItemDatabase bossItemDatabase;
    public HeroDatabase heroDatabase;

    public ItemData itemReward1, itemReward2, itemReward3;
    public GameObject heroReward1, heroReward2, heroReward3;

    public GameObject itemContainer1, itemContainer2, itemContainer3;
    public GameObject heroContainer1, heroContainer2, heroContainer3;
    public GameObject passiveRewardsContainer;

    public GameObject itemHero1, itemHero2, itemHero3;
    public Button giveItemHero1, giveItemHero2, giveItemHero3;
    public Button chosePassive1, chosePassive2, chosePassive3;
    public TMP_Text giveItemHero1Text, giveItemHero2Text, giveItemHero3Text;
    public TMP_Text passiveEffectText1, passiveEffectText2, passiveEffectText3;
    //PASSIVE REWARDS
    public List<TMP_Text> passiveRewardNames;

    public List<Button> choosePassiveRewardButtons;

    private ItemData pendingItemReward;
    private PassiveData PassiveReward1;
    private PassiveData PassiveReward2;
    private PassiveData PassiveReward3;

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
        getBossItemButton.onClick.AddListener(generateBossItemRewards);
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

        chosePassive1.onClick.AddListener(() => SelectPassiveReward(PassiveReward1));
        chosePassive2.onClick.AddListener(() => SelectPassiveReward(PassiveReward2));
        chosePassive3.onClick.AddListener(() => SelectPassiveReward(PassiveReward3));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void choseReward()
    {
        getItemButton.gameObject.SetActive(true);


    }
    public void choseItem()
    {
        getItemButton.gameObject.SetActive(true);
    }
    public void choseBossItem()
    {
        getBossItemButton.gameObject.SetActive(true);
    }
    public void choseHero()
    {
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
    public void generateBossItemRewards()
    {
        getBossItemButton.gameObject.SetActive(false);
        getHeroButton.gameObject.SetActive(false);
        itemContainer1.SetActive(true);
        itemContainer2.SetActive(true);
        itemContainer3.SetActive(true);
        itemReward1 = bossItemDatabase.GetRandomItem();
        itemReward2 = bossItemDatabase.GetRandomItem();
        itemReward3 = bossItemDatabase.GetRandomItem();
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
        List<GameObject> randomHeroes = heroDatabase.GetRandomHeroes(3);
        heroReward1 = randomHeroes[0];
        heroReward2 = randomHeroes[1];
        heroReward3 = randomHeroes[2];
        heroName1.text = heroReward1.GetComponent<Fighter>().unitName;
        heroName2.text = heroReward2.GetComponent<Fighter>().unitName;
        heroName3.text = heroReward3.GetComponent<Fighter>().unitName;

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


    List<PassiveData> generatedPassivesData = new List<PassiveData>();
    PassiveData chosenPassive;
    int indexOfHeroesForPassives = 0;

    public void GeneratePassives()
    {
        passiveRewardsContainer.SetActive(true);
        List<Fighter> heroes = CombatManager.Instance.GetHeroList();
        string heroName = CombatManager.Instance.currentTeam[indexOfHeroesForPassives].prefab.GetComponent<Fighter>().unitName;
        //Generate passives and attach to buttons+
        List<PassiveData> passives = CombatManager.Instance.passiveDatabase.GetRandomPassives(3);

        passiveEffectText1.text = passives[0].description;
        passiveEffectText2.text = passives[1].description;
        passiveEffectText3.text = passives[2].description;
        PassiveReward1 = passives[0];
        PassiveReward2 = passives[1];
        PassiveReward3 = passives[2];
    }




    public void GeneratePassiveRewards()
    {

    }


    public void SelectPassiveReward(PassiveData passive)
    {
        //Hide UI
        passiveRewardsContainer.SetActive(false);

        //add Passive to hero
        Passive logic = PassiveFactory.Create(passive);
        CombatManager.Instance.currentTeam[indexOfHeroesForPassives].passives.Add(logic);
        indexOfHeroesForPassives++;
        if (indexOfHeroesForPassives < CombatManager.Instance.currentTeam.Count)
        {

            GeneratePassives();
        }
        else
        {
            //Continue cause passive distribution finished'
            MapUIManager.Instance.GenerateMap();
            GameManager.Instance.ChangeState(GameManager.GameState.combatReward);

        }



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
