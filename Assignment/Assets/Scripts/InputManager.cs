using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] private InputAction pauseAction;
    [SerializeField] private InputAction interactAction;

    #region Initialization
    private void Awake() 
    {
        if(instance == null) //Set up static instance
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Multiple Input Managers Found");
            Destroy(this);
        }

        GameManager.instance.OnStateChange.AddListener(HandleStateChange); //Add listener for game state changes
    }
    #endregion

    #region State Management
    private void HandleStateChange()
    {
        if (GameManager.instance.CurrentState == GameState.Playing)
        {
            EnableActions();
        }
        else
        {
            DisableActions();
        }
    }
    private void EnableActions() //Enable input actions
    {
        pauseAction.performed += onPauseAction;
        pauseAction.Enable();
        interactAction.performed += onInteractAction;
        interactAction.Enable();
    }

    private void DisableActions() //Disable input actions
    {
        pauseAction.performed -= onPauseAction;
        pauseAction.Disable();
        interactAction.performed -= onInteractAction;
        interactAction.Disable();
    }
    #endregion

    #region On Action Functions
    private void onPauseAction(InputAction.CallbackContext context)
    {
        GameManager.instance.PauseGame();
        Debug.Log("PAUSE GAME");
    }

    private void onInteractAction(InputAction.CallbackContext context)
    {
        Debug.Log("INTERACT");
    }
    #endregion
}
