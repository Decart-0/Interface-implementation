using System;
using UnityEngine;

[RequireComponent(typeof(DetectorGround))]
[RequireComponent(typeof(InputScheme))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerFlipper))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMotion : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isOnGround;
    private float _direction;

    private InputScheme _inputScheme;
    private Rigidbody2D _rigidbody;
    private DetectorGround _detectorGround;
    private PlayerFlipper _playerFlipper;
    private PlayerAnimator _playerAnimator;

    public event Action Moving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputScheme = GetComponent<InputScheme>();
        _detectorGround = GetComponent<DetectorGround>();
        _playerFlipper = GetComponent<PlayerFlipper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _isOnGround = true;
    }

    private void OnEnable()
    {
        _detectorGround.GroundStatusChanged += UpdateIsGround;
    }

    private void Update()
    {
        Move();
        Moving?.Invoke();
        _playerAnimator.SetupMotion(_direction);

        if (Input.GetKeyDown(_inputScheme.Jump) && _isOnGround)
        {
            Jump();
        }
    }

    private void OnDisable()
    {
        _detectorGround.GroundStatusChanged -= UpdateIsGround;
    }

    public void UpdateIsGround()
    {
        _isOnGround = _detectorGround.IsOnGround;
    }

    private void Move()
    {
        _direction = Input.GetAxis(_inputScheme.AxisHorizontal);

        if (_direction != 0)
        {
            _rigidbody.velocity = new Vector2(_direction * _speed, _rigidbody.velocity.y);
            _playerFlipper.Flip(_direction);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}