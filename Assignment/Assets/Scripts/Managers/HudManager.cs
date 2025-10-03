using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public static HudManager activeInstance;
    [SerializeField] private TMP_Text _collectablesDisplay;
    [SerializeField] private TMP_Text _towersDisplay;
    [SerializeField] private GameObject _interactionTooltip;

    private void Awake()
    {
        activeInstance = this;
        DisableTooltip();
    }

    public void UpdateHUD()
    {
        _collectablesDisplay.text = LevelManager.activeInstance.PiecesCollected.ToString();
        _towersDisplay.text = LevelManager.activeInstance.CompletedTowers.ToString() + "/" + LevelManager.activeInstance.TotalTowers.ToString();
    }

    public void EnableTooltip() { _interactionTooltip.SetActive(true); }

    public void DisableTooltip() { _interactionTooltip.SetActive(false); }

    public void OnDestroy()
    {
        activeInstance = null;
    }
}
