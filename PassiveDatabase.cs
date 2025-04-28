using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class PassiveDatabase : MonoBehaviour
{

    private List<Passive> allPassives = new List<Passive>();


    void Awake()
    {
        LoadAllPassives();
    }


    void LoadAllPassives(){

        //Find whatever inherits from Passive
        var passiveTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t=> t.IsSubclassOf(typeof(Passive))&& !t.IsAbstract);

        foreach(var type in passiveTypes)
        {
            Passive passiveInstance = (Passive)Activator.CreateInstance(type);
            allPassives.Add(passiveInstance);

            Debug.Log($"Loaded Passive: {passiveInstance.passiveName} - {passiveInstance.description}");
        }

    }

}
