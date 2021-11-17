using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraOffsetx;
    [SerializeField] private float cameraOffsety;
    [SerializeField] private float offsetAmount = 1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraOffset = new Vector3(cameraOffsetx, cameraOffsety, -10);
         cameraOffsety = PlayerMove.rb.velocity.y;
         cameraOffsetx = PlayerMove.rb.velocity.x;
         
         Debug.Log(cameraOffsety);
         transform.localPosition = Vector3.Lerp(PlayerMove.rb.transform.position,cameraOffset * offsetAmount,100f);
    }

    private void FixedUpdate()
    {
        
    }
}
