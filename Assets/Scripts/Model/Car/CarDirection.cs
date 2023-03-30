using UnityEngine;

public class CarDirection : MonoBehaviour
{
    [SerializeField] private Transform _fromPoint;
    [SerializeField] private Transform _toPoint;

    public Vector2 Direction
    {
        get
        {
            Vector2 direction = new Vector2(_toPoint.position.x - _fromPoint.position.x,
                _toPoint.position.y -_fromPoint.position.y);
            return direction.normalized;
        }
    }
    
    private void OnDrawGizmos()
    {
        Debug.DrawLine(_fromPoint.position, _toPoint.position, Color.green);
    }
}
