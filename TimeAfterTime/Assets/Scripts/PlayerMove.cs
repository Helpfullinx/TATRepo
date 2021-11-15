using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField] private float moveSpeedHor = 50f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float groundCheckDis = 1f;
    
    private float moveAmountVer = 0f;
    private float moveAmountHor = 0f;
    private Rigidbody2D rb;
    private CapsuleCollider2D _capsuleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        Debug.DrawRay(new Vector3(_capsuleCollider2D.bounds.center.x,_capsuleCollider2D.bounds.min.y),Vector3.down * (groundCheckDis), Color.green);
        /*
        Debug.Log(Grounded());
        */
        Debug.Log(Input.GetKey(KeyCode.Space));
        
        if (Grounded() & Input.GetKey(KeyCode.Space))
        {
            moveAmountVer = jumpHeight;
        }
        else
        {
            moveAmountVer = rb.velocity.y;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveAmountHor = Input.GetAxis("Horizontal") * moveSpeedHor;
        
        rb.velocity = new Vector2(moveAmountHor, moveAmountVer);
    }

    bool Grounded()
    {
        LayerMask groundMask = LayerMask.GetMask("Ground");
        Vector2 playerBottom = new Vector2(_capsuleCollider2D.bounds.center.x,_capsuleCollider2D.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(playerBottom,Vector2.down, groundCheckDis, groundMask);
        return hit;
    }
}