using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public event Action ClickStartEvent;
    public event Action ClickEndEvent;
    
    [field: SerializeField]
    public bool IsClicked { get; private set; }

    public void OnPointerUp(PointerEventData eventData)
    {
        ClickEndEvent?.Invoke();
        IsClicked = false;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        ClickStartEvent?.Invoke();
        IsClicked = true;
    }

    private void Update()
    {
        Debug.Log(gameObject.name + ": " + IsClicked);
    }
}
