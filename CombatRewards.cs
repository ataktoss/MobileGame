using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CombatRewards : MonoBehaviour
{

    //public Button getHeroButton;
    public static CombatRewards Instance{ get; private set; }
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


    
    void Awake(){
        if(Instance != null && Instance != this){
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



    public void SelectItem(ItemData item)
    {
        CombatManager.Instance.currentTeam[0].equippedItems.Add(item);
        Debug.Log("Adde the item :" + item.itemName);
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

}
