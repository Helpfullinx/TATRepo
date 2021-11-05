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
    
    public Rigidbody2D rb;
    public CapsuleCollider2D _capsuleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        Debug.DrawRay(_capsuleCollider2D.bounds.min,Vector3.down * (_capsuleCollider2D.bounds.extents.y + groundCheckDis), Color.green);
        Debug.Log(Grounded());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveAmountHor = Input.GetAxis("Horizontal") * moveSpeedHor * Time.deltaTime;
        float moveAmountVer = Input.GetAxis("Jump") * jumpHeight * Time.deltaTime;
        transform.Translate(moveAmountHor, moveAmountVer, 0f);
    }

    bool Grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_capsuleCollider2D.bounds.min,Vector2.down,_capsuleCollider2D.bounds.extents.y + groundCheckDis);
        return hit;
    }
}