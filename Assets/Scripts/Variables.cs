using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variables : MonoBehaviour
{   
    //Target List
    [Header("Ball Variables")]
    public List<GameObject> targetPool;
    public int ballScore;
    public float ballGravityScaler;
    public float ballScaler;
    public float ballJumpHeight;
    
    
    //Bar Variables
    [Header("Bar Variables")]
    public Transform barPosition;
    public Transform barScale;
    
    //UI Variables
    [Header("UI Variables")]
    public Text scoreText;
    public Text timeText;
    
    //Testing Variables
    [Header("Testing Toggles")]
    [Tooltip("Toggle automated testing functions")] public bool testing;
    [Tooltip("Used with Testing toggle to test fails.")] public bool testingFails;
    [Tooltip("Used with Testing toggle to test passes.")] public bool testingPasses;
}
