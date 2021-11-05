using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeedHor = 50f;
    [SerializeField] float moveSpeedVer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmountHor = Input.GetAxis("Horizontal") * moveSpeedHor * Time.deltaTime;
        float moveAmountVer = Input.GetAxis("Vertical") * moveSpeedVer * Time.deltaTime;
        transform.Translate(moveAmountHor, moveAmountVer, 0f);
    }
}
