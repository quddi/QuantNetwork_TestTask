using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementButton))]
public class MovementButtonPresenter : MonoBehaviour
{
    [SerializeField] private Color _clickedColor;
    [SerializeField] private Color _notClickedColor;
    [SerializeField] private Image _buttonImage;
    
    private MovementButton _movementButton;

    private void Awake()
    {
        _movementButton = GetComponent<MovementButton>();
    }

    private void OnClickStart()
    {
        _buttonImage.color = _clickedColor;
    }
    
    private void OnClickEnd()
    {
        _buttonImage.color = _notClickedColor;
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
