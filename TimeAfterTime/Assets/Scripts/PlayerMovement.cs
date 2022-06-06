using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeedHor = 50f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private Vector2 groundCheckCenter = new Vector2(0f,-.5f);
    [SerializeField] private Vector2 groundCheckCapsuleSize = new Vector2(1.1f,1.1f);
    [SerializeField] private LayerMask groundLayer;
    
    private Vector2 _moveAmount = Vector2.zero;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log(Grounded());
        
    }
    void FixedUpdate()
    {
        if (Grounded() && Input.GetKey(KeyCode.Space)) {
            _moveAmount.y = jumpHeight; 
        } else {
            _moveAmount.y = _rb.velocity.y;
        }
        
        _moveAmount.x = Input.GetAxis("Horizontal") * moveSpeedHor;
        
        _rb.velocity = _moveAmount;
    }

    /// <summary>
    /// Checks to see if player is grounded
    /// </summary>
    /// <returns>returns true if grounded</returns>
    private bool Grounded()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(_rb.position + groundCheckCenter, groundCheckCapsuleSize, CapsuleDirection2D.Vertical, -90, Vector2.down, 0, groundLayer);
        return hit.collider != null;
    }
    
    
}