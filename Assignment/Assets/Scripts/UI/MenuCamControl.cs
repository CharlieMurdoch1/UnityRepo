using UnityEngine;

public class MenuCamControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform _currentMount;
    public float _speed = 5f;

    public void setMount(Transform newMount)
    {
        _currentMount = newMount;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _currentMount.position, _speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, _currentMount.rotation, _speed);
    }
}
