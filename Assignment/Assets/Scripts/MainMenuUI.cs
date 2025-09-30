using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnNewGameClick()
    {
        GameManager.instance.StartNewGame();
    }

    public void OnLoadLevelClick()
    {

    }

    public void OnSettingsClick()
    {

    }
}
