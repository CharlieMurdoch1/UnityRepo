using UnityEngine;
using TMPro;

public class PlayerCollision3D : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Screw"))
        {
            scoreManager.AddScrew(1);
            Destroy(obj.gameObject);
        }
    }
}
