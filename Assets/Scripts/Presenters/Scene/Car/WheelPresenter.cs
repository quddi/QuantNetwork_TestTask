using UnityEngine;

public class WheelPresenter : MonoBehaviour
{
    [SerializeField] private float _angle = 60.0f;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void RotateForward()
    {
        _transform.Rotate(Vector3.forward, -_angle);
    }

    public void RotateBackward()
    {
        _transform.Rotate(Vector3.forward, _angle);
    }
}
