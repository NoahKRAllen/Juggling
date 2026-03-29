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
    
    
    //Ball Variables
    public List<BallReaction> targets;
    public float ballRadius;
    public float ballSpeed;

    //Bar Variables
    public GameObject targetBar;
    public float targetBarPosition;
    public float targetBarSize;
    //Player Variables


    public bool testing;
    public bool testingFails;
    public bool testingPasses;
}
