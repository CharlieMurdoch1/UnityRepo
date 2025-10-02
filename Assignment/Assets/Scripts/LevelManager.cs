using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager activeInstance;

    [SerializeField] private HudManager _hudManager;

    [Header("Progress Stats")]
    public int PiecesCollected {  get; private set; } = 0; 

    private void Awake()
    {
        activeInstance = this;
        InitializeLevel();
    }

    private void InitializeLevel()
    {
        _hudManager = Instantiate(_hudManager);
        _hudManager.UpdateHUD();
    }

    public void CollectPiece() //Called when the player collects a new tower piece
    {
        PiecesCollected++;
        UpdateProgress();
    }

    private void UpdateProgress() //Called every time the player makes progress to update UI and check win condition
    {
        _hudManager.UpdateHUD();
    }
}
