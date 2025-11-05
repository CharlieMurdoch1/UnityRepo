using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI screwText;
    public int totalScrews = 0;

    public void AddScrew(int amount)
    {
        totalScrews += amount;
        screwText.text = "Screws: " + totalScrews;
    }
}
