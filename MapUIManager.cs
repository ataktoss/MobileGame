using System.Collections.Generic;
using UnityEngine;


public class MapUIManager : MonoBehaviour
{
    
    public List<MapNodeUI> allNodes;
    public int finalLayerIndex = 2;
    private float bottomY;
    void Start()
    {
        
        bottomY = FindLowestY();

        foreach (var node in allNodes)
        {
            bool isBottom = Mathf.Approximately(node.transform.position.y , bottomY);
            node.AssignRandomType(isFinalLayer: isBottom);
            
            
            
        }
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
