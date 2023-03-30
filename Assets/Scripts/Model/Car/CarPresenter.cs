using UnityEngine;

[RequireComponent(typeof(CarDirection))]
[RequireComponent(typeof(Rigidbody2D))]
public class CarPresenter : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private MovementButton _forwardMovementButton;
    [SerializeField] private MovementButton _backwardMovementButton;

    private CarDirection _carDirection;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _carDirection = GetComponent<CarDirection>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_forwardMovementButton.IsClicked)
        {
            _rigidbody.AddForce(_carDirection.Direction * _force, ForceMode2D.Impulse);
            Debug.Log("Moving forward");
        }

        if (_backwardMovementButton.IsClicked)
        {
            _rigidbody.AddForce(_carDirection.Direction * -_force, ForceMode2D.Force);
            Debug.Log("Moving backward");
        }
    }
}
