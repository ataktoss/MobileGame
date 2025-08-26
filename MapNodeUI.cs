using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNodeUI : MonoBehaviour
{
    public enum NodeType { Combat, Shop, Elite, Boss }

    [Header("Assigned at runtime")] 
    public NodeType nodeType;
    public EncounterGroupSO assignedEncounter;

    [Header("Node Connections")] 
    public List<MapNodeUI> connectedNodes = new(); // children (set in Inspector)
    [HideInInspector] public List<MapNodeUI> parents = new(); // auto-filled at runtime
    [HideInInspector] public int layer; // 0 = bottom row

    [Header("Visuals")] 
    public Image icon;
    public Color combatColor = Color.red;
    public Color shopColor = Color.green;
    public Color eliteColor = Color.magenta;
    public Color bossColor = Color.black;
    public GameObject reachableGlow; // optional highlight when interactable

    Button _btn;

    void Awake()
    {
        _btn = GetComponent<Button>();
        if (_btn != null)
            _btn.onClick.AddListener(OnClick);
    }

    public void SetType(NodeType t)
    {
        nodeType = t;
        UpdateVisuals();
    }

    public void SetInteractable(bool interactable)
    {
        if (_btn) _btn.interactable = interactable;
        if (reachableGlow) reachableGlow.SetActive(interactable);
    }

    public void UpdateVisuals()
    {
        if (icon == null) return;
        switch (nodeType)
        {
            case NodeType.Combat: icon.color = combatColor; break;
            case NodeType.Shop:   icon.color = shopColor;   break;
            case NodeType.Elite:  icon.color = eliteColor;  break;
            case NodeType.Boss:   icon.color = bossColor;   break;
        }
    }

    void OnClick()
    {
        if (_btn != null && !_btn.interactable) return;
        MapUIManager.Instance.HandleNodeClicked(this);
    }
}