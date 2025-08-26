// // InvalidAABBWatcher.cs
// // Put on an empty GameObject in your scene. Press Play.
// // It scans all active Canvases each frame and logs the first bad object it finds.

// using UnityEngine;
// using System.Text;

// public class InvalidAABBWatcher : MonoBehaviour
// {
//     [Header("What counts as 'absurdly large'?")]
//     public float hugeThreshold = 1e6f;

//     [Header("Behavior")]
//     public bool stopOnFirstFind = true;   // pauses Editor when it finds one (Editor only)
//     public bool logEveryFrame = false;    // otherwise logs once per offender per session

//     private readonly System.Collections.Generic.HashSet<int> _reported = new();

//     void Update()
//     {
//         var canvases = FindObjectsOfType<Canvas>(includeInactive: false);
//         foreach (var canvas in canvases)
//         {
//             var rts = canvas.GetComponentsInChildren<RectTransform>(includeInactive: false);
//             foreach (var rt in rts)
//             {
//                 if (rt == null) continue;

//                 var t = rt.transform;
//                 if (IsBad(t.position) || IsBad(t.localPosition) || IsBad(rt.anchoredPosition))
//                 {
//                     Report(rt, "position/anchoredPosition");
//                     if (stopOnFirstFind) return;
//                 }

//                 if (IsBad(t.localScale))
//                 {
//                     Report(rt, "localScale");
//                     if (stopOnFirstFind) return;
//                 }

//                 // sizeDelta & rect size
//                 var size = rt.sizeDelta;
//                 if (IsBad(size) || IsBad(rt.rect.width) || IsBad(rt.rect.height))
//                 {
//                     Report(rt, "sizeDelta/rect");
//                     if (stopOnFirstFind) return;
//                 }
//             }
//         }
//     }

//     bool IsBad(Vector3 v) => IsBad(v.x) || IsBad(v.y) || IsBad(v.z) || IsHuge(v);
//     bool IsBad(Vector2 v) => IsBad(v.x) || IsBad(v.y) || IsHuge(v);
//     bool IsBad(float f)   => float.IsNaN(f) || float.IsInfinity(f);
//     bool IsHuge(Vector3 v)=> Mathf.Abs(v.x) > hugeThreshold || Mathf.Abs(v.y) > hugeThreshold || Mathf.Abs(v.z) > hugeThreshold;
//     bool IsHuge(Vector2 v)=> Mathf.Abs(v.x) > hugeThreshold || Mathf.Abs(v.y) > hugeThreshold;

//     void Report(RectTransform rt, string field)
//     {
//         // avoid spamming the same object unless logEveryFrame is on
//         int id = rt.gameObject.GetInstanceID();
//         if (!logEveryFrame && _reported.Contains(id)) return;
//         _reported.Add(id);

//         var t = rt.transform;
//         var sb = new StringBuilder();
//         sb.AppendLine("Invalid AABB likely caused by bad UI transform values.");
//         sb.AppendLine($"Offender: {GetPath(rt.transform)} (activeInHierarchy={rt.gameObject.activeInHierarchy})");
//         sb.AppendLine($"Field group: {field}");
//         sb.AppendLine($"worldPos={t.position} localPos={t.localPosition} anchoredPos={rt.anchoredPosition}");
//         sb.AppendLine($"localScale={t.localScale} sizeDelta={rt.sizeDelta} rect=({rt.rect.width}x{rt.rect.height})");
//         sb.AppendLine($"Canvas: {rt.GetComponentInParent<Canvas>()?.name}");

// #if UNITY_EDITOR
//         // If this object came from a prefab instance, print some prefab context
//         var stage = UnityEditor.PrefabUtility.GetPrefabInstanceStatus(rt.gameObject);
//         if (stage != UnityEditor.PrefabInstanceStatus.NotAPrefab)
//         {
//             var source = UnityEditor.PrefabUtility.GetCorrespondingObjectFromSource(rt.gameObject);
//             if (source != null)
//                 sb.AppendLine($"Prefab Source: {UnityEditor.AssetDatabase.GetAssetPath(source)}");
//         }
// #endif

//         Debug.LogError(sb.ToString(), rt);

// #if UNITY_EDITOR
//         if (stopOnFirstFind)
//         {
//             UnityEditor.EditorApplication.isPaused = true; // pause on first offender
//             UnityEditor.Selection.activeObject = rt.gameObject;
//             UnityEditor.EditorGUIUtility.PingObject(rt.gameObject);
//         }
// #endif
//     }

//     static string GetPath(Transform t)
//     {
//         var path = t.name;
//         while (t.parent != null)
//         {
//             t = t.parent;
//             path = t.name + "/" + path;
//         }
//         return path;
//     }
// }
