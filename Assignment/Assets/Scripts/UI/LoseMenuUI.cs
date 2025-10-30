using UnityEngine;

public class LoseMenuUI : MonoBehaviour
{
    public void OnReturnClick()
    {
        GameManager.instance.ReturnToMenu();
    }
}
