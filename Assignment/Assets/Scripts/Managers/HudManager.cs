using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _collectablesDisplay;

    public void UpdateHUD()
    {
        _collectablesDisplay.text = LevelManager.activeInstance.PiecesCollected.ToString();
    }
}
