using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TesterController : MonoBehaviour
{   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Variables.Instance.testing)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.Instance.testingPasses)
        {
            foreach (BallReaction t in Variables.Instance.targets)
            {
                if (t.InRange())
                {
                    t.Clicked();
                }
            }
        }
    }
}
