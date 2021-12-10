using Bolt;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeedHor = 50f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private Vector2 groundCheckCenter = new Vector2(0f,-.5f);
    [SerializeField] private Vector2 groundCheckCapsuleSize = new Vector2(1.1f,1.1f);
    [SerializeField] private GameObject cameraParent;
    [SerializeField] private LayerMask groundLayer;
    
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
    }
    //Update is called once per frame
    private void Update()
    {
        
        Debug.Log(Grounded());
        
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
        RaycastHit2D hit = Physics2D.CapsuleCast(_rb.position + groundCheckCenter, groundCheckCapsuleSize, CapsuleDirection2D.Vertical, -90, Vector2.down, 0, groundLayer);
        return hit.collider != null;
    }
}