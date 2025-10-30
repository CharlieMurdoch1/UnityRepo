using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Collect()
    {
        AudioManager.Instance.PlaySound("Pickup_Sound");
        LevelManager.activeInstance.CollectPiece();
        Destroy(gameObject);
    }
}
