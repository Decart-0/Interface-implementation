using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class DetectorGround : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private int _currentAmountGround = 0;

    public event Action GroundStatusChanged;

    public bool IsOnGround => _currentAmountGround > 0;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Ground>())
        {
            _currentAmountGround++;
            GroundStatusChanged?.Invoke();
            _playerAnimator.PlayJump(IsOnGround);

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Ground>())
        {
            _currentAmountGround--;
            GroundStatusChanged?.Invoke();
            _playerAnimator.PlayJump(IsOnGround);
        }
    }
}