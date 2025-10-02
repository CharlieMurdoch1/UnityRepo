using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    //[SerializeField] private Collider2D _collider;
    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Player");
    }

    public UnityEvent OnCollision;
}
