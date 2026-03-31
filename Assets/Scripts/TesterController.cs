using UnityEngine;

#if UNITY_EDITOR
public class TesterController : MonoBehaviour
{
    private readonly float _delay = 2;
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
    void LateUpdate()
    {
        if (!variables.testing) return;
        _currentDelay -= Time.deltaTime; 
        if (variables.testingPasses)
        {
            foreach (GameObject t in variables.ballObjectPool)
            {
                try
                {
                    if (t.activeInHierarchy)
                        if (t.GetComponent<BallReaction>().InRange())
                        {
                            t.GetComponent<BallReaction>().Clicked();
                        }
                }
                catch (System.Exception e)
                {
                    Debug.Log($"An exception has occured trying to click on {t.name} " + e.Message);
                }
            }
        }

        if (variables.testingFails && _currentDelay <= 0)
        {
            foreach (GameObject t in variables.ballObjectPool)
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
#endif
