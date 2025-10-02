using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] private InputAction pauseAction;
    [SerializeField] private InputAction interactAction;
    [SerializeField] private InputAction jumpAction;

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
        jumpAction.performed += onJumpAction;
        jumpAction.Enable();
    }

    private void DisableActions() //Disable input actions
    {
        pauseAction.performed -= onPauseAction;
        pauseAction.Disable();
        interactAction.performed -= onInteractAction;
        interactAction.Disable();
        jumpAction.performed -= onJumpAction;
        jumpAction.Disable();
    }
    #endregion

    #region On Action Functions
    private void onPauseAction(InputAction.CallbackContext context)
    {
        GameManager.instance.PauseGame();
        pauseEvent.Invoke();
        Debug.Log("PAUSE GAME");
    }

    private void onInteractAction(InputAction.CallbackContext context)
    {
        interactEvent.Invoke();
        Debug.Log("INTERACT");
    }

    private void onJumpAction(InputAction.CallbackContext context)
    {
        jumpEvent.Invoke();
        Debug.Log("JUMP");
    }
    #endregion

    #region Public Events
    public UnityEvent jumpEvent;
    public UnityEvent interactEvent;
    public UnityEvent pauseEvent;
    #endregion
}
