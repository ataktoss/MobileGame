using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNodeUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public enum NodeType{
        Combat,
        Shop,
        Elite,
        Boss
    }

    [Header("Assigned at runtime")]
    public NodeType nodeType;

    public EncounterGroupSO assignedEncounter;
    

    [Header("Node Connections")]
    public List<MapNodeUI> connectedNodes; // drag these manually in the Editor



    [Header("Visuals")]
    public Image icon;
    public Color combatColor = Color.red;
    public Color shopColor = Color.green;
    public Color eliteColor = Color.magenta;
    public Color bossColor = Color.black;
    
    
    public void AssignRandomType(bool isFinalLayer = false){
        if(isFinalLayer){
            nodeType = NodeType.Boss;
        }
        else{
            float roll = UnityEngine.Random.value;
            if(roll<0.15f){
                nodeType = NodeType.Shop;
                //Debug.Log("This is Shop now");
                
            }
            else if(roll < 0.30f){
                nodeType = NodeType.Elite;
                //Debug.Log("This is Elite now");
            }
            else{
                nodeType = NodeType.Combat;
                //Debug.Log("This is Combat now");
            }
        }

        //UPDATE VISUAL
        UpdateVisuals();

    }


    public void SetInteractable(bool interactable)
    {
        GetComponent<Button>().interactable = interactable;
    }

    public void UpdateVisuals(){
        if(icon == null) return;

        switch(nodeType){
            case NodeType.Combat: icon.color = combatColor; break;
            case NodeType.Shop: icon.color = shopColor; break;
            case NodeType.Elite: icon.color = eliteColor; break;
            case NodeType.Boss: icon.color = bossColor; break;
        }
    }

    public void OnClick() {
        Debug.Log("Clicked the button");
        //if(assignedEncounter != null){
        //Debug.Log($"Entering {nodeType} encounter: {assignedEncounter.groupID}");
        MapUIManager.Instance.OnNodeCliked(this);
        //
        if (nodeType == NodeType.Shop)
        {
            //DO SHOP STUFF
            GameManager.Instance.ChangeState(GameManager.GameState.Shop);

        }

        if (nodeType == NodeType.Combat || nodeType == NodeType.Elite || nodeType == NodeType.Boss)
        {
            CombatManager.Instance.CurrentEncounter = assignedEncounter;
            CombatManager.Instance.AsignEnemiesAndHeroes();
            CombatManager.Instance.SetupCombat();
        }
        
        //}
    }




}
