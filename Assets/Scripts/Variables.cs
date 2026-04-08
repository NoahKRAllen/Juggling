using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Variables : MonoBehaviour
{   
    //Target List
    [Header("Ball Variables")]
    public List<GameObject> ballObjectPool;
    public int ballScore;
    public float ballGravityScaler;
    public float ballScaler;
    public Color ballColor;
    
    //Bar Variables
    [Header("Bar Variables")]
    public Transform barPosition;
    public Transform barScale;
    
    //UI Variables
    [Header("UI Variables")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    
    #if UNITY_EDITOR
    //Testing Variables
    [Header("Testing Toggles")]
    [Tooltip("Toggle automated testing functions")] public bool testing;
    [Tooltip("Used with Testing toggle to test fails.")] public bool testingFails;
    [Tooltip("Used with Testing toggle to test passes.")] public bool testingPasses;
    #endif
}
