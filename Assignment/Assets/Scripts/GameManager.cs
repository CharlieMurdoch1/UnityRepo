using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MusicManager _musicManager;
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
            Debug.LogError("More than one GameManager instance in the scene");
        }

        SettingsHandler.LoadPrefs(); //Load Settings data from playerPrefs
        BindObjects();
    }

    private void BindObjects() //Creates instances of managers and binds them
    {
        _audioManager = Instantiate(_audioManager);
        _musicManager = Instantiate(_musicManager);
    }

    public void StartNewGame() //Called on NewGame UI button click
    {
        LoadLevel("Level_01");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    
}
