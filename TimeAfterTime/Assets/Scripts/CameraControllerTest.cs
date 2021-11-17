using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    public Transform Player;
    [SerializeField]public float dampTime = 0.4f;
    private Vector3 _cameraPos;
    private Vector3 _velocity = Vector3.zero;
    //Vector3.zero is shorthand for Vector3(0, 0, 0)

    void Update()
    {
        _cameraPos = new Vector3(Player.position.x, Player.position.y, -10f);
        /*
         *So basically, it smoothly follows starting at it's current position to whatever the players position is constantly
         *Which makes it look like it's following the player, but really it's just changing the SmoothDamo
         *Target position to the player's position constantly
         *I haven't figured out how to make it go past the player and give a view
         *of what's ahead yet
         */
        transform.position =  Vector3.SmoothDamp(gameObject.transform.position, _cameraPos, ref _velocity, dampTime);
    }
}
