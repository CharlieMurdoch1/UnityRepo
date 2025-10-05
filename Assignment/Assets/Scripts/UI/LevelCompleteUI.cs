using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    public void OnReturnClick()
    {
        GameManager.instance.ReturnToMenu();
    }
}
