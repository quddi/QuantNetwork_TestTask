using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private LayerMask _groundLayerMask;
    
    private const string _groundTag = "Ground";

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        IsGrounded = false;
    }

    private void FixedUpdate()
    {
        IsGrounded =Physics2D.BoxCast(_boxCollider2D.bounds.center, 
            _boxCollider2D.bounds.size, 
            angle: 0f,
            Vector2.down,
            distance: 0.1f,
            _groundLayerMask);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size);
    }
}