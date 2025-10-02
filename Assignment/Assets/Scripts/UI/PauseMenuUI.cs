using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public void OnYesClick()
    {
        GameManager.instance.ReturnToMenu();
    }

    public void OnNoClick() 
    {
        GameManager.instance.ResumeGame();
    }
}
