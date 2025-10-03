using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _collectablesDisplay;
    [SerializeField] private TMP_Text _towersDisplay;

    public void UpdateHUD()
    {
        _collectablesDisplay.text = LevelManager.activeInstance.PiecesCollected.ToString();
        _towersDisplay.text = LevelManager.activeInstance.CompletedTowers.ToString() + "/" + LevelManager.activeInstance.TotalTowers.ToString();
    }
}
