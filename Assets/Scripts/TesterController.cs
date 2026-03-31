using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TesterController : MonoBehaviour
{
    private readonly float _delay = 5;
    private float _currentDelay;
    [SerializeField]private Variables variables;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!variables)
        {
            gameObject.SetActive(false);
        }
        _currentDelay = _delay;
    }

    // Update is called once per frame
    void Update()
    {
        _currentDelay -= Time.deltaTime;
        if (variables.testingPasses)
        {
            foreach (GameObject t in variables.targetPool)
            {
                if(t.activeInHierarchy)
                    if (t.GetComponent<BallReaction>().InRange())
                    {
                        t.GetComponent<BallReaction>().Clicked();
                    }
            }
        }

        if (variables.testingFails && _currentDelay <= 0)
        {
            foreach (GameObject t in variables.targetPool)
            {
                if (t.activeInHierarchy)
                    if (!t.GetComponent<BallReaction>().InRange())
                    {
                        t.GetComponent<BallReaction>().Clicked();
                    }
            }
            _currentDelay = _delay;
        }
    }
}
