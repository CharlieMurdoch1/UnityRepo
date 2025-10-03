using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        if (_player == null) return;

        float targetX = _player.position.x + _offset.x;
        Vector3 desiredPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
    }
}
