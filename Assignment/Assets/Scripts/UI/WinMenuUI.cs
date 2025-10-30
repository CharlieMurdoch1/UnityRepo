using UnityEngine;

public class WinMenuUI : MonoBehaviour
{
    public void OnNextClick()
    {
        LevelManager.activeInstance.EndLevel();
    }
}
