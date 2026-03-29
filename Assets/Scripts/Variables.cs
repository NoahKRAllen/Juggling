using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Variables : MonoBehaviour
{
    public static Variables Instance{get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    
    //Target List
     public List<GameObject> targets;

    //Bar Variables
    
    //Testing Variables
    public bool testing;
    public bool testingFails;
    public bool testingPasses;
}
