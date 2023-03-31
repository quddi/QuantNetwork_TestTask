using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementButton))]
public class MovementButtonPresenter : MonoBehaviour
{
    [SerializeField] private Sprite _clickedSprite;
    [SerializeField] private Sprite _notClickedSprite;
    [SerializeField] private Image _buttonImage;
    
    private MovementButton _movementButton;

    private void Awake()
    {
        _movementButton = GetComponent<MovementButton>();
    }

    private void OnClickStart()
    {
        _buttonImage.sprite = _clickedSprite;
    }
    
    private void OnClickEnd()
    {
        _buttonImage.sprite = _notClickedSprite;
    }

    private void OnEnable()
    {
        _movementButton.ClickStartEvent += OnClickStart;
        _movementButton.ClickEndEvent += OnClickEnd;
    }

    private void OnDisable()
    {
        _movementButton.ClickStartEvent -= OnClickStart;
        _movementButton.ClickEndEvent -= OnClickEnd;
    }
}
