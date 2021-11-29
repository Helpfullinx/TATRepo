using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeedHor = 50f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float groundCheckDis = 1f;
    [SerializeField] private GameObject cameraParent;
    
    [SerializeField] [Range(0f,5f)] private float cameraParentOffset = 5f;
    
    private Vector2 _moveAmount = Vector2.zero;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _capsuleCollider2D;
    
    private Vector3 _rbPos;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        LayerMask.GetMask("Ground");
    }
    //Update is called once per frame
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
    //FixedUpdate is called at a fixed rate
    void FixedUpdate()
    {
        _moveAmount.x = Input.GetAxis("Horizontal") * moveSpeedHor;
        
        _rb.velocity = _moveAmount;

        _rbPos = _rb.transform.position;
        
        if (_rb.velocity.x < 0)
        {
            cameraParent.transform.position = new Vector3(_rbPos.x - cameraParentOffset, _rbPos.y,0);
        }
        else if (_rb.velocity.x > 0)
        {
            cameraParent.transform.position = new Vector3(_rbPos.x + cameraParentOffset, _rbPos.y,0);
        }
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