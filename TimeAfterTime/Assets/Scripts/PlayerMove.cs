using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float moveSpeedHor = 50f;
    [SerializeField] float moveSpeedVer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveAmountHor = Input.GetAxis("Horizontal") * moveSpeedHor * Time.deltaTime;
        float moveAmountVer = Input.GetAxis("Jump") * moveSpeedVer * Time.deltaTime;
        transform.Translate(moveAmountHor, moveAmountVer, 0f);
    }
}