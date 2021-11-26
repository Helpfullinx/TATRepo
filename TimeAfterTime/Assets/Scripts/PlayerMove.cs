using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeedHor = 50f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float groundCheckDis = 1f;
    
    private Vector2 _moveAmount = Vector2.zero;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _capsuleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        Debug.DrawRay(new Vector3(_capsuleCollider2D.bounds.center.x,_capsuleCollider2D.bounds.min.y),Vector3.down * (groundCheckDis), Color.green);

        if (Grounded() & Input.GetKey(KeyCode.Space))
        {
            _moveAmount.y = jumpHeight;
        }
        else
        {
            _moveAmount.y = _rb.velocity.y;
        }
    }
    
    void FixedUpdate()
    {
        _moveAmount.x = Input.GetAxis("Horizontal") * moveSpeedHor;
        
        _rb.velocity = _moveAmount;
    }

    /// <summary>
    /// Checks to see if player is grounded
    /// </summary>
    /// <returns>returns true if grounded</returns>
    private bool Grounded()
    {
        LayerMask groundMask = LayerMask.GetMask("Ground");
        Vector2 playerBottom = new Vector2(_capsuleCollider2D.bounds.center.x,_capsuleCollider2D.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(playerBottom,Vector2.down, groundCheckDis, groundMask);
        return hit;
    }
}