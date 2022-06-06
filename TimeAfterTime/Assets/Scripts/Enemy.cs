using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float detectionDistance;
    
    private Rigidbody2D _rb;
    private GameObject _player;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _player = ProximityCheck(transform.position, detectionDistance);
        Debug.Log(_player);
        FollowPlayer();
    }

    // Checks certain distance for gameobject with player script attached and returns that Gameobject
    private GameObject ProximityCheck(Vector2 origin, float distance)
    {
        GameObject player;
        RaycastHit2D hit2D = Physics2D.CircleCast(origin, distance, Vector2.right);
        if (hit2D.transform.gameObject.TryGetComponent(out Player playerComponent)) {
            player = hit2D.transform.gameObject;
        }
        else {
            player = null;
        }

        Debug.DrawLine(origin,origin + Vector2.right * distance ,Color.green);
        return player;
    }

    //follows position of nearest player
    private void FollowPlayer()
    {
        
    }
}
