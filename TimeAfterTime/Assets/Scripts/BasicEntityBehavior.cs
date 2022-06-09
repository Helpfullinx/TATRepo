using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEntityBehavior : MonoBehaviour
{
    [SerializeField] private Vector2 groundCheckCenter = new Vector2(0f,-.5f);
    [SerializeField] private Vector2 groundCheckCapsuleSize = new Vector2(1.1f,1.1f);
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody2D _rb;
    
    public Rigidbody2D Rb
    {
        get => _rb;
        set => _rb = value;
    }

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Checks to see if player is grounded
    /// </summary>
    /// <returns>returns true if grounded</returns>
    public bool Grounded()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(_rb.position + groundCheckCenter, groundCheckCapsuleSize, CapsuleDirection2D.Vertical, -90, Vector2.down, 0, groundLayer);
        return hit.collider != null;
    }
    
    public void WallCheck()
    {
        
    }
}
