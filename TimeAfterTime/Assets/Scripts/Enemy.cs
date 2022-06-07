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
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    
    private Rigidbody2D _rb;
    private GameObject _player;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _player = ProximityCheck(transform.position, detectionDistance);
        FollowPlayer(_rb,_player, movementSpeed,jumpHeight);
    }

    // Checks certain distance for gameobject with player script attached and returns that Gameobject
    private GameObject ProximityCheck(Vector2 origin, float distance)
    {
        GameObject player;
        RaycastHit2D hit2D = Physics2D.CircleCast(origin, distance, Vector2.right, 0, LayerMask.GetMask("Entities"));
        if (hit2D.transform.gameObject.TryGetComponent(out Player playerComponent)) {
            player = hit2D.transform.gameObject;
        } else {
            return null;
        }
        Debug.DrawLine(origin,origin + Vector2.right * distance ,Color.green);
        return player;
    }

    //follows position of nearest player
    private void FollowPlayer(Rigidbody2D enemyRb, GameObject player, float movementSpeed, float jumpHeight)
    {
        Vector3 direction = Vector3.Normalize(player.transform.position - enemyRb.transform.position);
        if (_player != null) {
            enemyRb.velocity = new Vector2(direction.x * movementSpeed,enemyRb.velocity.y);
        }

        if (_player != null && direction.y > .7f) {
            enemyRb.velocity = new Vector2(enemyRb.velocity.x, direction.y * jumpHeight);
        }
    }

    private void WallCheck()
    {
        
    }
}
