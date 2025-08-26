using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance {get; private set;}

    public enum GameState{PickingNode,Combat,Shop,Event,combatReward,passiveChoice}
    public GameState CurrentState;

    //do not touch from another script
    public GameObject mapPanel,combatPanel,shopPanel,rewardPanel;

    public CombatRewards combatRewards;

    public FillShop fillShop;

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        
    }

    public void ChangeState(GameState newState){
        CurrentState = newState;
        switch (newState)
        {
            case GameState.PickingNode:
                ShowMap();
                break;
            case GameState.Combat:
                SetupCombat();
                break;
            case GameState.Shop:
                OpenShop();
                break;
            case GameState.combatReward:
                combatReward();
                break;
            case GameState.passiveChoice:
                ShowPassiveChoice();
                break;
        }


    }

    public void SetupCombat(){
        mapPanel.SetActive(false);
        // combatPanel.SetActive(true);
        // shopPanel.SetActive(false);
        // rewardPanel.SetActive(false);
    }
    public void combatReward()
    {
        // mapPanel.SetActive(false);
        // combatPanel.SetActive(false);
        // shopPanel.SetActive(false);
        // rewardPanel.SetActive(true);
        // CombatRewards.Instance.choseReward();
        Debug.Log("Generating reward buttons");
    }

    public void OpenShop()
    {
        mapPanel.SetActive(false);
        //combatPanel.SetActive(false);
        shopPanel.SetActive(true);
        //rewardPanel.SetActive(false);

        fillShop.FillShopWithItems();
    }
    

    

    public void ShowMap()
    {
        mapPanel.SetActive(true);
        //combatPanel.SetActive(false);
        shopPanel.SetActive(false);
        //rewardPanel.SetActive(false);

    }

    public void ShowPassiveChoice()
    {
        
    }

    public void AddItemToInventory(ItemData item)
    {
        Debug.Log("The name of the item is : " + item.itemName);
        //DO STUFF WITH ITEM HERE
    }


    






}
