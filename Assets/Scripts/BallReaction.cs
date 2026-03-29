using UnityEngine;

public class BallReaction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        var vector3 = gameObject.transform.position;
        vector3.y += 4;
        gameObject.transform.position = vector3;
    }
}
