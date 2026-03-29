using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TesterController : MonoBehaviour
{
    private readonly float _delay = 5;
    private float _currentDelay;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Variables.Instance.testing)
        {
            gameObject.SetActive(false);
        }
        _currentDelay = _delay;
    }

    // Update is called once per frame
    void Update()
    {
        _currentDelay -= Time.deltaTime;
        if (Variables.Instance.testingPasses)
        {
            foreach (GameObject t in Variables.Instance.targets)
            {
                if(t.activeInHierarchy)
                    if (t.GetComponent<BallReaction>().InRange())
                    {
                        t.GetComponent<BallReaction>().Clicked();
                    }
            }
        }

        if (Variables.Instance.testingFails && _currentDelay <= 0)
        {
            foreach (GameObject t in Variables.Instance.targets)
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
