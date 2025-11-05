using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private GameObject _uiCanvas;
    //[SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;


    #region Initialization
    private void Awake()
    {
        if (instance == null) //Set up static instance
        {
            instance = this;
            DontDestroyOnLoad(this);
            CreateMenuInstances();
        }
        else
        {
            Debug.LogError("Multiple UI Managers Found");
            Destroy(this);
        }

        GameManager.instance.OnStateChange.AddListener(HandleStateChange); //Add listener for game state changes
    }

    private void CreateMenuInstances()
    {
        _uiCanvas = Instantiate(_uiCanvas.gameObject);
        DontDestroyOnLoad(_uiCanvas);

        //_mainMenu = Instantiate(_mainMenu, _uiCanvas.transform);
        //DontDestroyOnLoad(_mainMenu.gameObject);

        _pauseMenu = Instantiate(_pauseMenu, _uiCanvas.transform);
        DontDestroyOnLoad(_pauseMenu.gameObject);

        _winMenu = Instantiate(_winMenu, _uiCanvas.transform);
        DontDestroyOnLoad(_winMenu.gameObject);

        _loseMenu = Instantiate(_loseMenu, _uiCanvas.transform);
        DontDestroyOnLoad(_loseMenu.gameObject);

        HandleStateChange(); //Call initially to open the main menu on game start.
    }
    #endregion

    #region State Management
    private void HandleStateChange()
    {
        //_mainMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _loseMenu.SetActive(false);
        _winMenu.SetActive(false);

        switch (GameManager.instance.CurrentState)
        {
            case GameState.MainMenu:
                //_mainMenu.SetActive(true);
                break;

            case GameState.Paused:
                _pauseMenu.SetActive(true);
                break;

            case GameState.Win:
                _winMenu.SetActive(true);
                break;

            case GameState.Lose:
                _loseMenu.SetActive(true);
                break;
        }
    }
    #endregion

    
}
