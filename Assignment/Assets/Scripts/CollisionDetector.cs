using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnCollision.Invoke();
            Debug.Log("Hit Player");
        }
    }

    public UnityEvent OnCollision;
}
