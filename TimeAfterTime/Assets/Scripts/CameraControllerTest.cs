using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    [SerializeField] private Transform cameraParentTransform;
    [SerializeField] private float dampTime = 0.4f;
    [SerializeField] [Range(0f, 1f)] private float playerMovementFactor = 1f;
    [SerializeField][Range(0f,1f)] private float vertOffsetScaler = 1;
    [SerializeField][Range(0f, 1f)] private float horOffsetScaler = 1;
    [SerializeField] [Range(0f,5f)] private float cameraParentOffset = 5f;
    private Rigidbody2D _playerRb;
    private Vector3 _velocity = Vector3.zero;
    private Vector2 _playerVelocity;
    private Vector2 _lastPos;
    private Vector2 _cameraTargetPos;
    private Facing _facingDirection;

    private void Start()
    {
        _playerRb = transform.root.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _lastPos = transform.position;
        Vector2 playerRbPos = _playerRb.transform.position;
        
        if (Input.GetAxisRaw("Horizontal") < 0 && _facingDirection != Facing.Left) {
            _facingDirection = Facing.Left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && _facingDirection != Facing.Right) {
            _facingDirection = Facing.Right;
        }
        
        _cameraTargetPos = new Vector2(playerRbPos.x + GetFacingFloatValue(_facingDirection) * cameraParentOffset, playerRbPos.y);
        _playerRb.transform.localScale = new Vector2(GetFacingFloatValue(_facingDirection),1);
        
        _playerVelocity = new Vector2(_playerRb.velocity.x * horOffsetScaler, _playerRb.velocity.y * vertOffsetScaler);
        
        Debug.DrawLine(_lastPos, _cameraTargetPos + _playerVelocity, Color.green);
        
        /*
         *So basically, it smoothly follows starting at it's current position to whatever the players position is constantly
         *Which makes it look like it's following the player, but really it's just changing the SmoothDamo
         *Target position to the player's position constantly
         *I haven't figured out how to make it go past the player and give a view
         *of what's ahead yet
         */
        transform.position =  Vector3.SmoothDamp(_lastPos , _cameraTargetPos + _playerVelocity * playerMovementFactor, ref _velocity, dampTime);
    }

    private float GetFacingFloatValue(Facing facing)
    {
        switch (facing)
        {
            case Facing.Left:
                return -1.0f;
            case Facing.Right:
                return 1.0f;
        }

        return 0;
    }


    private enum Facing

    {
        Left,
        Right
    }
}
