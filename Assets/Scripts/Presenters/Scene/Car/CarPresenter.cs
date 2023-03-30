using UnityEngine;

[RequireComponent(typeof(CarDirection))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CarMovement))]
public class CarPresenter : MonoBehaviour
{
    [SerializeField] private float _movementForce;
    [SerializeField] private float _torque;
    [SerializeField] private float _minVelocityForWheelsRotation;
    [SerializeField] private WheelPresenter _backWheelPresenter;
    [SerializeField] private WheelPresenter _frontWheelPresenter;
    
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
        {
            _rigidbody.AddForce(_carDirection.Direction * _movementForce, ForceMode2D.Impulse);
            _frontWheelPresenter.RotateForward();
            _backWheelPresenter.RotateForward();
        }

        if (_carMovement.MovementType == CarMovementType.MovingBackward)
        {
            _rigidbody.AddForce(_carDirection.Direction * -_movementForce, ForceMode2D.Impulse);
            _frontWheelPresenter.RotateBackward();
            _backWheelPresenter.RotateBackward();
        }
        
        if (_carMovement.MovementType == CarMovementType.RotatingForward)
            _rigidbody.AddTorque(-_torque);
        
        if (_carMovement.MovementType == CarMovementType.RotatingBackward)
            _rigidbody.AddTorque(_torque);

        if (_carMovement.MovementType == CarMovementType.None && _rigidbody.velocity.x > _minVelocityForWheelsRotation)
        {
            _frontWheelPresenter.RotateForward();
            _backWheelPresenter.RotateForward();
        }
        
        if (_carMovement.MovementType == CarMovementType.None && _rigidbody.velocity.x < -_minVelocityForWheelsRotation)
        {
            _frontWheelPresenter.RotateBackward();
            _backWheelPresenter.RotateBackward();
        }
    }
}
