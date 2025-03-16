using System;
using UnityEngine;

[RequireComponent(typeof(DetectorGround))]
[RequireComponent(typeof(InputService))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HorizontalFlipper))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMotion : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isOnGround;
    private float _direction;

    private InputService _inputService;
    private Rigidbody2D _rigidbody;
    private DetectorGround _detectorGround;
    private HorizontalFlipper _horizontalFlipper;
    private PlayerAnimator _playerAnimator;

    public event Action Moving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputService = GetComponent<InputService>();
        _detectorGround = GetComponent<DetectorGround>();
        _horizontalFlipper = GetComponent<HorizontalFlipper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _isOnGround = true;
    }

    private void OnEnable()
    {
        _detectorGround.GroundStatusChanged += UpdateIsGround;
        _inputService.JumpPressed += Jump;
    }

    private void Update()
    {
        Move();
        Moving?.Invoke();
        _playerAnimator.PlayRun(_direction);
    }

    private void OnDisable()
    {
        _detectorGround.GroundStatusChanged -= UpdateIsGround;
        _inputService.JumpPressed -= Jump;
    }

    public void UpdateIsGround()
    {
        _isOnGround = _detectorGround.IsOnGround;
    }

    private void Move()
    {
        _direction = _inputService.GetMovementInput();

        if (_direction != 0)
        {
            _rigidbody.velocity = new Vector2(_direction * _speed, _rigidbody.velocity.y);
            _horizontalFlipper.Flip(_direction);
        }
    }

    private void Jump()
    {
        if (_isOnGround) 
        { 
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}