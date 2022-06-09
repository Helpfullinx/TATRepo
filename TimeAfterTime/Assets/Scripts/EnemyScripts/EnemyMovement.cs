using PlayerScripts;
using UnityEngine;

namespace EnemyScripts
{
    [RequireComponent(typeof(BasicEntityBehavior))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float detectionDistance;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private LayerMask playerLayer;

        private GameObject _player;
        private BasicEntityBehavior _basicEntityBehavior;

        private void Start()
        {
            _basicEntityBehavior = GetComponent<BasicEntityBehavior>();
        }

        void FixedUpdate()
        {
            _player = ProximityCheck(transform.position, detectionDistance, playerLayer);
            FollowPlayer(_basicEntityBehavior,_player, movementSpeed,jumpHeight);
        }

        // Checks certain distance for gameobject with player script attached and returns that Gameobject
        private GameObject ProximityCheck(Vector2 origin, float distance, LayerMask playerLayer)
        {
            GameObject player;
            RaycastHit2D hit2D = Physics2D.CircleCast(origin, distance, Vector2.right, 0, playerLayer);
        
            if (hit2D.transform.gameObject.TryGetComponent(out Player playerComponent)) {
                player = hit2D.transform.gameObject;
            } else {
                return null;
            }
        
            Debug.DrawLine(origin,origin + Vector2.right * distance ,Color.green);
            return player;
        }

        //follows position of nearest player
        private void FollowPlayer(BasicEntityBehavior behavior, GameObject player, float movementSpeed, float jumpHeight)
        {
            Rigidbody2D enemyRb = behavior.Rb;
            Vector3 direction = Vector3.Normalize(player.transform.position - enemyRb.transform.position);
        
            if (_player != null) {
                enemyRb.velocity = new Vector2(direction.x * movementSpeed,enemyRb.velocity.y);
            }

            if (_player != null && direction.y > .7f && behavior.Grounded()) {
                enemyRb.velocity = new Vector2(enemyRb.velocity.x, direction.y * jumpHeight);
            }
        }
    }
}
