// using UnityEngine;

// public class PassiveManager : MonoBehaviour
// {
//     public PassiveDatabase1 database;

//     public static PassiveManager Instance;
//     void Awake()
//     {
//         if (Instance != null && Instance != this)
//         {
//             Destroy(this.gameObject);
//             return;
//         }
//         Instance = this;
//     }
//     public Passive GetRandomPassive()
//     {
//         if (Instance == null || Instance.database == null || Instance.database.allPassives == null || Instance.database.allPassives.Count == 0)
//         {
//             Debug.LogWarning("PassiveManager is not initialized properly.");
//             return null;
//         }

//         int randomIndex = Random.Range(0, Instance.database.allPassives.Count);
//         PassiveData randomData = Instance.database.allPassives[randomIndex];
//         return PassiveFactory.Create(randomData);
//     }

    

// }
