using UnityEngine;

[RequireComponent(typeof(CarDirection))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CarMovement))]
public class CarPresenter : MonoBehaviour
{
    [SerializeField] private float _movementForce;
    [SerializeField] private float _torque;
    
    private CarDirection _carDirection;
    private Rigidbody2D _rigidbody;
    private CarMovement _carMovement;

    private void Awake()
    {
        _carDirection = GetComponent<CarDirection>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _carMovement = GetComponent<CarMovement>();
    }

    private void FixedUpdate()
    {
        if (_carMovement.MovementType == CarMovementType.MovingForward)
            _rigidbody.AddForce(_carDirection.Direction * _movementForce, ForceMode2D.Impulse);

        if (_carMovement.MovementType == CarMovementType.MovingBackward)
            _rigidbody.AddForce(_carDirection.Direction * -_movementForce, ForceMode2D.Impulse);
        
        if (_carMovement.MovementType == CarMovementType.RotatingForward)
            _rigidbody.AddTorque(-_torque);
        
        if (_carMovement.MovementType == CarMovementType.RotatingBackward)
            _rigidbody.AddTorque(_torque);
    }
}
