using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager activeInstance;
    [SerializeField] private List<Tower> _towers;

    [SerializeField] private HudManager _hudManager;

    [SerializeField] private string _nextLevelName;

    [Header("Progress Stats")]
    public int PiecesCollected { get; private set; } = 0;
    public int TotalTowers { get; private set; } = 0;
    public int CompletedTowers { get; private set; } = 0;

    private void Awake()
    {
        activeInstance = this;
        InitializeLevel();
    }

    private void InitializeLevel() //Set up level-specific managers
    {
        _hudManager = Instantiate(_hudManager);
        _hudManager.UpdateHUD();
    }

    public void CollectPiece() //Called when the player collects a new tower piece
    {
        PiecesCollected++;
        UpdateProgress();
    }

    public void RemovePiece() //Called when the player collects a new tower piece
    {
        PiecesCollected--;
        UpdateProgress();
    }

    private int GetCompletedTowers() //Loop through all towers and check how many are completed
    {
        int _completeTowersCount = 0;

        foreach (Tower tower in _towers)
        {
            if (tower.IsCompleted) { _completeTowersCount++; }
        }

        return _completeTowersCount;
    }

    public void UpdateProgress() //Called every time the player makes progress to update UI and check win condition
    {
        TotalTowers = _towers.Count; //Get the total number of cell towers in the level

        CompletedTowers = GetCompletedTowers(); //Update the number of towers completed by the player

        _hudManager.UpdateHUD(); //Update the HUD display values

        GetPercent();
    }

    public void OnDestroy()
    {
        activeInstance = null;
    }

    public int GetPercent()
    {
        int _percentage = GetCompletedTowers() / TotalTowers;
        Debug.Log("Percentage: " + _percentage.ToString());
        return _percentage;
    }

    public void EndLevel()
    {
        if (GetCompletedTowers() == TotalTowers)
        {
            Debug.Log("Moving to next level");
            if(_nextLevelName == "Main_Menu")
            {
                GameManager.instance.ReturnToMenu();
                return;
            }
            SceneManager.LoadScene(_nextLevelName);
        }
        else
        {
            Debug.Log("Complete level first");
        }


    }
}
