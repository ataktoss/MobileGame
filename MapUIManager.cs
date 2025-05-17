using System.Collections.Generic;
using UnityEngine;


public class MapUIManager : MonoBehaviour
{
    
    public List<MapNodeUI> allNodes;
    public int finalLayerIndex = 2;
    public BiomeEncounterPoolSO currentBiomePool;

    // GIA TESTING SIGOURO ENCOUNTER STO COMBAT
    public EncounterGroupSO readyEncounter;

    public MapNodeUI currentNode;

    private float bottomY;
    void Start()
    {
        
        bottomY = FindLowestY();

        foreach (var node in allNodes)
        {
            bool isBottom = Mathf.Approximately(node.transform.position.y , bottomY);
            node.AssignRandomType(isFinalLayer: isBottom);
            AssignEncountersToCombatNodes();
            
            
        }
    }

    void AssignEncountersToCombatNodes(){
        foreach(var node in allNodes){
            switch(node.nodeType){
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

    EncounterGroupSO GetRandomFrom(List<EncounterGroupSO> list){
        return list.Count ==0?null: list[Random.Range(0,list.Count)];
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


}
