using System.Collections.Generic;
using UnityEngine;


public class MapUIManager : MonoBehaviour
{
    public static MapUIManager Instance;

    public List<MapNodeUI> allNodes;
    public int finalLayerIndex = 2;
    public BiomeEncounterPoolSO currentBiomePool;

    // GIA TESTING SIGOURO ENCOUNTER STO COMBAT
    public EncounterGroupSO readyEncounter;

    public MapNodeUI currentNode;

    private float bottomY;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {

        bottomY = FindLowestY();

        foreach (var node in allNodes)
        {
            bool isBottom = Mathf.Approximately(node.transform.position.y, bottomY);
            node.AssignRandomType(isFinalLayer: isBottom);
            AssignEncountersToCombatNodes();


        }
    }

    void AssignEncountersToCombatNodes()
    {
        foreach (var node in allNodes)
        {
            switch (node.nodeType)
            {
                case MapNodeUI.NodeType.Combat:
                    node.assignedEncounter = GetRandomFrom(currentBiomePool.normalEncounters);
                    //node.assignedEncounter = readyEncounter;
                    break;
                case MapNodeUI.NodeType.Elite:
                    node.assignedEncounter = GetRandomFrom(currentBiomePool.eliteEncounters);
                    break;
                case MapNodeUI.NodeType.Boss:
                    node.assignedEncounter = GetRandomFrom(currentBiomePool.bossEncounters);
                    break;







            }
        }
    }

    EncounterGroupSO GetRandomFrom(List<EncounterGroupSO> list)
    {
        return list.Count == 0 ? null : list[Random.Range(0, list.Count)];
    }



    private float GetBottomY()
    {
        float lowest = float.MaxValue;
        foreach (var node in allNodes)
        {
            if (node.transform.position.y < lowest)
                lowest = node.transform.position.y;
        }
        return lowest;
    }


    private float FindLowestY()
    {
        float lowest = float.MaxValue;
        foreach (var node in allNodes)
        {
            float y = node.transform.position.y;
            if (y < lowest)
                lowest = y;
        }
        return lowest;
    }

    //Sets clickable nodes 
    public void OnNodeCliked(MapNodeUI clickedNode)
    {
        currentNode = clickedNode;
        clickedNode.SetInteractable(false);
        foreach (var node in allNodes)
        {
            //node.SetInteractable(node == clickedNode);
        }

        foreach (var connected in clickedNode.connectedNodes)
        {
            connected.SetInteractable(true);
        }
    }

}
