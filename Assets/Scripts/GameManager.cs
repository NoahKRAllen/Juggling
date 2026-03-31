using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Variables
    public float ballActivateDelay;
    [SerializeField] private int score;
    [SerializeField] private int time;
    [SerializeField] private Variables variables;
    
    //Used for randomized placement of balls before dropping them
    [SerializeField] private float maxSpawnX;
    [SerializeField] private float minSpawnX;
    [SerializeField] private float spawnY;
    [SerializeField] private float ballSpawnDelay;
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
