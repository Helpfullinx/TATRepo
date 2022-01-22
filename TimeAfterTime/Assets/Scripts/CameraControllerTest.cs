using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float dampTime = 0.4f;
    [SerializeField][Range(0f,1f)] private float cameraMultiplier = 1f;
    [SerializeField][Range(0f,1f)] private float vertOffsetAmount = 1;
    [SerializeField][Range(0f, 1f)] private float horOffsetAmount = 1;
    private Vector3 _cameraPos;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _playerVelocity;
    //Vector3.zero is shorthand for Vector3(0, 0, 0)

    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        _cameraPos = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f);
        _playerVelocity = new Vector3(playerRb.velocity.x * horOffsetAmount, playerRb.velocity.y * vertOffsetAmount, 0);
        
        Debug.DrawLine(gameObject.transform.position, _cameraPos + _playerVelocity, Color.green);
        
        /*
         *So basically, it smoothly follows starting at it's current position to whatever the players position is constantly
         *Which makes it look like it's following the player, but really it's just changing the SmoothDamo
         *Target position to the player's position constantly
         *I haven't figured out how to make it go past the player and give a view
         *of what's ahead yet
         */
        transform.position =  Vector3.SmoothDamp(gameObject.transform.position , _cameraPos + (_playerVelocity * cameraMultiplier), ref _velocity, dampTime);
    }
}
