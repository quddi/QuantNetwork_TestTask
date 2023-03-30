using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private MovementButton _forwardMovementButton;
    [SerializeField] private MovementButton _backwardMovementButton;
    [SerializeField] private GroundChecker _groundChecker;
    
    [field: SerializeField] public CarMovementType MovementType { get; private set; }
    
    private void OnForwardButtonClickStart()
    {
        if (_backwardMovementButton.IsClicked)
        {
            MovementType = CarMovementType.None;
            return;
        }

        if (_groundChecker.IsGrounded)
            MovementType = CarMovementType.MovingForward;
        else
            MovementType = CarMovementType.RotatingForward;
    }
    
    private void OnForwardButtonClickEnd()
    {
        if (_backwardMovementButton.IsClicked)
            MovementType = CarMovementType.MovingBackward;
        else
            MovementType = CarMovementType.None;
    }
    
    private void OnBackwardButtonClickStart()
    {
        if (_forwardMovementButton.IsClicked)
        {
            MovementType = CarMovementType.None;
            return;
        }
        
        if (_groundChecker.IsGrounded)
            MovementType = CarMovementType.MovingBackward;
        else
            MovementType = CarMovementType.RotatingBackward;
    }
    
    private void OnBackwardButtonClickEnd()
    {
        if (_forwardMovementButton.IsClicked)
            MovementType = CarMovementType.MovingForward;
        else
            MovementType = CarMovementType.None;
    }

    private void OnEnable()
    {
        _forwardMovementButton.ClickStartEvent += OnForwardButtonClickStart;
        _forwardMovementButton.ClickEndEvent += OnForwardButtonClickEnd;
        _backwardMovementButton.ClickStartEvent += OnBackwardButtonClickStart;
        _backwardMovementButton.ClickEndEvent += OnBackwardButtonClickEnd;
    }

    private void OnDisable()
    {
        _forwardMovementButton.ClickStartEvent -= OnForwardButtonClickStart;
        _forwardMovementButton.ClickEndEvent -= OnForwardButtonClickEnd;
        _backwardMovementButton.ClickStartEvent -= OnBackwardButtonClickStart;
        _backwardMovementButton.ClickEndEvent -= OnBackwardButtonClickEnd;
    }
}
