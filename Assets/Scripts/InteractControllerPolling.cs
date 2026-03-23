using UnityEngine;
using UnityEngine.InputSystem;

public class InteractControllerPolling : MonoBehaviour
{
    InputAction _interactActionButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interactActionButton = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        //Polling method of obtaining player input
        if (_interactActionButton.WasPressedThisFrame())
        {
            PlayerInteraction();
        }
    }

    private void PlayerInteraction()
    {
        print(_interactActionButton.name);
    }
}
