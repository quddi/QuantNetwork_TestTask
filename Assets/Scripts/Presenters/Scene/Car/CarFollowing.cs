using UnityEngine;

public class CarFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothing = 5f;

    private Transform _transform;
    private Vector3 _offset;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _offset = _transform.position - _target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(_transform.position, targetPosition, _smoothing * Time.deltaTime);
    }
}
