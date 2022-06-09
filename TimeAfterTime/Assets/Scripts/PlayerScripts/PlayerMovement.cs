using UnityEngine;
using Debug = UnityEngine.Debug;

namespace PlayerScripts
{
    [RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D),typeof(BasicEntityBehavior))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeedHor = 50f;
        [SerializeField] private float jumpHeight = 10f;

        private BasicEntityBehavior _basicEntityBehavior;
        private Vector2 _moveAmount = Vector2.zero;
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _basicEntityBehavior = GetComponent<BasicEntityBehavior>();
        }
    
        void Update()
        {
            Debug.Log(_basicEntityBehavior.Grounded());
        }
    
        void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            if (_basicEntityBehavior.Grounded() && Input.GetKey(KeyCode.Space)) {
                _moveAmount.y = jumpHeight; 
            } else {
                _moveAmount.y = _rb.velocity.y;
            }
        
            _moveAmount.x = Input.GetAxis("Horizontal") * moveSpeedHor;
        
            _rb.velocity = _moveAmount;
        }
    }
}