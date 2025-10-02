using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public enum GameState { MainMenu, Playing, Paused}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState CurrentState { get; private set; } = GameState.MainMenu;

    //Manager Prefabs
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private UiManager _uiManager;

    #region Initialization
    private void Awake() //Called on game start
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }

        SettingsHandler.LoadPrefs(); //Load Settings data from playerPrefs
        BindObjects();
    }

    private void BindObjects() //Creates instances of managers and binds them
    {
        _audioManager = Instantiate(_audioManager);
        //_musicManager = Instantiate(_musicManager);
        _inputManager = Instantiate(_inputManager);
        _uiManager = Instantiate(_uiManager);
    }

    #endregion

    #region State Management
    private void SetState(GameState state) //Changes game state
    {
        if (state == CurrentState) return;

        CurrentState = state; //Set the new state

        OnStateChange.Invoke(); //Call event on state change

        if (state == GameState.Paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        Debug.Log("Set game state to " + state);
    }

    public UnityEvent OnStateChange; //Invoked when state changes
    #endregion

    #region Runtime Functions
    public void StartNewGame()
    {
        LoadLevel("Level_01");
        SetState(GameState.Playing);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        SetState(GameState.Playing);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        SetState(GameState.MainMenu);
    }

    public void PauseGame()
    {
        SetState(GameState.Paused); 
    }

    public void ResumeGame()
    {
        SetState(GameState.Playing);
    }

    #endregion
}
