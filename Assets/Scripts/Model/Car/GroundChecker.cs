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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //IsGrounded = false;
    }

    private void FixedUpdate()
    {
        IsGrounded =Physics2D.BoxCast(_boxCollider2D.bounds.center, 
            _boxCollider2D.bounds.size, 
            angle: 0f,
            Vector2.down,
            distance: 0.1f,
            _groundLayerMask);
        
        Debug.Log(IsGrounded);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Vector3 size = new Vector3(_boxCollider2D.size.x, _boxCollider2D.size.y, 0f);
        Vector3 center = new Vector3(_boxCollider2D.offset.x, _boxCollider2D.offset.y, 0f) + transform.position;
        
        Gizmos.DrawWireCube(center, size);
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(center, center + (Vector3.down * 0.1f));
    }
}