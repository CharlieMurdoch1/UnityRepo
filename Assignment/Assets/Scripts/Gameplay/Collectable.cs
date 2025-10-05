using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Collect()
    {
        //AudioManager.Instance.PlaySound("collect_item");
        LevelManager.activeInstance.CollectPiece();
        Destroy(gameObject);
    }
}
