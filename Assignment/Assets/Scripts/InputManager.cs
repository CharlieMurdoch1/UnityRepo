using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] private InputAction pauseAction;
    [SerializeField] private InputAction interactAction;

    private void Awake() //Set up static instance
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Multiple Input Managers Found");
            Destroy(this);
        }

        EnableActions();
    }

    public void EnableActions() //Enable input actions
    {
        pauseAction.performed += onPauseAction;
        pauseAction.Enable();

        interactAction.performed += onInteractAction;
        interactAction.Enable();

    }

    public void DisableActions()
    {
        pauseAction.Disable();
        interactAction.Disable();
    }

    private void onPauseAction(InputAction.CallbackContext context)
    {
        Debug.Log("PAUSE GAME");
    }

    private void onInteractAction(InputAction.CallbackContext context)
    {
        Debug.Log("INTERACT");
    }
}
