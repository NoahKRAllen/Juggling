using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractControllerCallbacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return; 
        //Debug.Log("there was a click at " + Mouse.current.position.ReadValue());
        if (Camera.main == null) return;

        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        var hit = Physics2D.GetRayIntersection(ray, 20);
        

        //Test hit exists, otherwise you get an error.
        if (!hit || !Variables.Instance.targets.Contains(hit.collider.gameObject)) return;
        hit.collider.gameObject.GetComponent<BallReaction>().Clicked();
        Debug.Log($"Hit {hit.collider.gameObject.name} with click at {Mouse.current.position.ReadValue()}");
    }
}
