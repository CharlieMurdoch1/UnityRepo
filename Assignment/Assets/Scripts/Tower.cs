using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Graphics Objects")]
    [SerializeField] private GameObject _brokenGraphics;
    [SerializeField] private GameObject _baseGraphics;
    [SerializeField] private GameObject _middleGraphics;
    [SerializeField] private GameObject _topGraphics;
    [SerializeField] private TMP_Text _displayText;
    [SerializeField] private GameObject _displayCanvas;

    [Header("States")]
    [SerializeField] private int _towerLevel = 0;
    public bool IsCompleted { get; private set; } = false;

    public void BuildTower()
    {
        if(LevelManager.activeInstance.PiecesCollected > 0 && IsCompleted == false)
        {
            LevelManager.activeInstance.RemovePiece(); //Remove piece from piece count

            _towerLevel++; //Increase Tower Level

            if(_towerLevel >= 3) { IsCompleted = true; } //Set tower to completed if 3 pieces have been added

            LevelManager.activeInstance.UpdateProgress(); //Update progress check on HUD and level completion status

            UpdateGraphics();
        }
    }

    private void UpdateGraphics()
    {
        //Update display text
        if (IsCompleted)
        {
            Destroy(_displayCanvas);
        }
        else
        {
            _displayText.text = _towerLevel.ToString() + "/3";
        }

        //Disable all graphics objects
        _brokenGraphics.SetActive(false);
        _baseGraphics.SetActive(false);
        _middleGraphics.SetActive(false);
        _topGraphics.SetActive(false);

        //Enable based on tower level
        switch (_towerLevel)
        {
            case 0:
                _brokenGraphics.SetActive(true);
                break;
            case 1:
                _baseGraphics.SetActive(true);
                break;
            case 2:
                _baseGraphics.SetActive(true);
                _middleGraphics.SetActive(true);
                break;
            case 3:
                _baseGraphics.SetActive(true);
                _middleGraphics.SetActive(true);
                _topGraphics.SetActive(true);
                break;
        }
    }
}
