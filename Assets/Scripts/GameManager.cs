using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Game Variables
    [SerializeField] private int score;
    [SerializeField] private float time;
    [SerializeField] private Variables variables;
    
    //Used for randomized placement of balls before dropping them
    [SerializeField] private float maxSpawnX;
    [SerializeField] private float minSpawnX;
    [SerializeField] private float spawnY;
    [SerializeField] private float ballSpawnDelay;
    private float _currentDelay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        score = 0;
        time = 0;
        _currentDelay = ballSpawnDelay;
        foreach (var ball in variables.ballObjectPool)
        {
            ball.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        _currentDelay -= Time.deltaTime;
        if (_currentDelay <= 0)
        {
            _currentDelay = ballSpawnDelay;
            foreach (var ball in variables.ballObjectPool)
            {
                if (!ball.activeInHierarchy)
                {
                    float spawnX = Random.Range(minSpawnX, maxSpawnX + 1);
                    ball.transform.position = new Vector3(spawnX, spawnY, 0);
                    ball.SetActive(true);
                    break;
                }
            }    
        }

        
    }

    public void AddScore(GameObject selectedBall, Rigidbody2D rb)
    {
        ResetBall(selectedBall, rb);
        score += variables.ballScore;
    }

    public void ResetBall(GameObject selectedBall, Rigidbody2D rb)
    {
        float spawnX = Random.Range(minSpawnX, maxSpawnX + 1);
        selectedBall.transform.position = new Vector3(spawnX, spawnY, 0);
        rb.linearVelocity = Vector3.zero;
        selectedBall.SetActive(false);
    }
}
