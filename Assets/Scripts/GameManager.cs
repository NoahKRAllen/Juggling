using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Variables
    public float ballActivateDelay;
    [SerializeField] private int score;
    [SerializeField] private int time;
    [SerializeField] private Variables variables;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        time = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
