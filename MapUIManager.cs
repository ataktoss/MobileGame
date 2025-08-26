using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapUIManager : MonoBehaviour
{
    public static MapUIManager Instance;

    [Header("Nodes (assign in Inspector)")] 
    public List<MapNodeUI> allNodes = new();

    [Header("Generation Weights")] 
    [Range(0f, 1f)] public float shopWeight = 0.15f;
    [Range(0f, 1f)] public float eliteWeight = 0f; // remaining becomes Combat

    [Header("Encounters")] 
    public BiomeEncounterPoolSO currentBiomePool;
    public EncounterGroupSO fallbackEncounter; // used if a list is empty

    [Header("Runtime")] 
    public MapNodeUI currentNode;

    // internal
    readonly List<List<MapNodeUI>> _layers = new(); // bottom (0) -> top (N)
    const float YTolerance = 4f; // how close y-values must be to count as same row

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Keep the old behavior: generate at startup
        GenerateMap();
    }

    /// <summary>
    /// Public entry point you can call from any other script to rebuild the map.
    /// Optional deterministic seed. Pass null for non-deterministic.
    /// </summary>
    [ContextMenu("Generate Map (Context Menu)")]
    public void GenerateMap(int? seed = null)
    {
        if (allNodes == null || allNodes.Count == 0)
        {
            Debug.LogError("MapUIManager: No nodes assigned.");
            return;
        }

        // Optional determinism
        if (seed.HasValue) Random.InitState(seed.Value);

        // Clean previous runtime state
        ClearRuntimeState();

        // Rebuild everything
        BuildParentsFromConnections();
        BuildLayersFromY();
        AssignTypesOnce();
        AssignEncountersToTypedNodes();
        InitializeInteractables();
    }

    /// <summary>
    /// Clears per-run data like current node, assigned encounters, type, interactables, and layers.
    /// </summary>
    void ClearRuntimeState()
    {
        currentNode = null;
        _layers.Clear();

        foreach (var n in allNodes)
        {
            if (n == null) continue;
            // Reset node fields that change during generation/run
            n.assignedEncounter = null;
            n.SetType(MapNodeUI.NodeType.Combat); // default before typing
            n.SetInteractable(false);
            n.layer = 0; // will be reassigned in BuildLayersFromY
            // NOTE: we do NOT touch connections or parents list here; parents are rebuilt below
            n.parents.Clear();
        }
    }

    #region Build graph helpers

    void BuildParentsFromConnections()
    {
        // parents already cleared in ClearRuntimeState, but safe either way
        foreach (var n in allNodes) n.parents.Clear();

        foreach (var n in allNodes)
        {
            foreach (var child in n.connectedNodes)
            {
                if (child != null && !child.parents.Contains(n))
                    child.parents.Add(n);
            }
        }
    }

    void BuildLayersFromY()
    {
        _layers.Clear();

        var ordered = allNodes
            .OrderBy(n => n.transform.position.y)
            .ToList();

        foreach (var node in ordered)
        {
            bool placed = false;
            for (int i = 0; i < _layers.Count; i++)
            {
                float repY = _layers[i][0].transform.position.y;
                if (Mathf.Abs(node.transform.position.y - repY) <= YTolerance)
                {
                    _layers[i].Add(node);
                    node.layer = i;
                    placed = true;
                    break;
                }
            }
            if (!placed)
            {
                _layers.Add(new List<MapNodeUI> { node });
                node.layer = _layers.Count - 1;
            }
        }

        foreach (var layer in _layers)
            layer.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));
    }

    #endregion

    #region Type & encounter assignment

    void AssignTypesOnce()
    {
        // everything starts as Combat (already set in ClearRuntimeState)

        int topLayer = _layers.Count - 1;
        if (topLayer < 0) return;

        // Choose exactly one Boss on the top layer
        var top = _layers[topLayer];
        var bossNode = top[Random.Range(0, top.Count)];
        bossNode.SetType(MapNodeUI.NodeType.Boss);

        // Everything else on the top layer defaults to Elite
        foreach (var n in top)
            if (n != bossNode) n.SetType(MapNodeUI.NodeType.Elite);

        // Assign types for lower layers
        for (int l = 0; l < topLayer; l++)
        {
            foreach (var n in _layers[l])
            {
                if (n == null || n == bossNode) continue;

                float roll = Random.value;
                float shopCutoff = shopWeight;
                float eliteCutoff = shopWeight + eliteWeight;

                if (roll < shopCutoff)        n.SetType(MapNodeUI.NodeType.Shop);
                else if (roll < eliteCutoff)  n.SetType(MapNodeUI.NodeType.Elite);
                else                          n.SetType(MapNodeUI.NodeType.Combat);
            }
        }

        // Ensure at least one Shop somewhere
        if (!allNodes.Any(n => n.nodeType == MapNodeUI.NodeType.Shop))
        {
            int mid = Mathf.Clamp(_layers.Count / 2, 0, topLayer - 1);
            if (_layers.Count > 1 && mid >= 0 && mid < _layers.Count)
            {
                var candidates = _layers[mid].Where(n => n.nodeType != MapNodeUI.NodeType.Boss).ToList();
                if (candidates.Count > 0)
                    candidates[Random.Range(0, candidates.Count)].SetType(MapNodeUI.NodeType.Shop);
            }
        }
    }

    void AssignEncountersToTypedNodes()
    {
        foreach (var node in allNodes)
        {
            switch (node.nodeType)
            {
                case MapNodeUI.NodeType.Combat:
                    node.assignedEncounter = GetRandomFrom(currentBiomePool?.normalEncounters);
                    break;
                case MapNodeUI.NodeType.Elite:
                    node.assignedEncounter = GetRandomFrom(currentBiomePool?.eliteEncounters);
                    break;
                case MapNodeUI.NodeType.Boss:
                    node.assignedEncounter = GetRandomFrom(currentBiomePool?.bossEncounters);
                    break;
                case MapNodeUI.NodeType.Shop:
                    node.assignedEncounter = null; // handled by Shop UI
                    break;
            }
        }
    }

    EncounterGroupSO GetRandomFrom(List<EncounterGroupSO> list)
    {
        if (list == null || list.Count == 0) return fallbackEncounter;
        return list[Random.Range(0, list.Count)];
    }

    #endregion

    #region Interactability & flow

    void InitializeInteractables()
    {
        foreach (var n in allNodes) n.SetInteractable(false);
        if (_layers.Count > 0)
        {
            foreach (var n in _layers[0]) n.SetInteractable(true);
        }
    }

    public void HandleNodeClicked(MapNodeUI clicked)
    {
        currentNode = clicked;

        // Lock everything, then open only the children of the clicked node
        foreach (var n in allNodes) n.SetInteractable(false);
        foreach (var child in clicked.connectedNodes)
        {
            if (child != null) child.SetInteractable(true);
        }

        // Transition into the content
        switch (clicked.nodeType)
        {
            case MapNodeUI.NodeType.Shop:
                GameManager.Instance.ChangeState(GameManager.GameState.Shop);
                break;
            case MapNodeUI.NodeType.Combat:
            case MapNodeUI.NodeType.Elite:
            case MapNodeUI.NodeType.Boss:
                CombatManager.Instance.CurrentEncounter = clicked.assignedEncounter;
                CombatManager.Instance.AsignEnemiesAndHeroes();
                CombatManager.Instance.SetupCombat();
                break;
        }
    }

    // Call this from your combat/shop code when the player returns to the map
    public void AdvanceFromCurrentNode()
    {
        if (currentNode == null) return;

        foreach (var n in allNodes) n.SetInteractable(false);
        foreach (var child in currentNode.connectedNodes)
        {
            if (child != null) child.SetInteractable(true);
        }
    }

    #endregion
}
