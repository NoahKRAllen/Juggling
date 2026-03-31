using UnityEngine;
using UnityEngine.InputSystem;

public class InteractControllerCallbacks : MonoBehaviour
{
    [SerializeField] private Variables variables;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return; 
        //Debug.Log("there was a click at " + Mouse.current.position.ReadValue());
        if (Camera.main == null) return;

        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        var hit = Physics2D.GetRayIntersection(ray, 20);
        

        //Test hit exists, otherwise you get an error.
        if (!hit || !variables.ballObjectPool.Contains(hit.collider.gameObject)) return;
        hit.collider.gameObject.GetComponent<BallReaction>().Clicked();
        Debug.Log($"Hit {hit.collider.gameObject.name} with click at {Mouse.current.position.ReadValue()}");
    }
}
