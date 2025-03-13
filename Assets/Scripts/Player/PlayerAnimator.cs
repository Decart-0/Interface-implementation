using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupMotion(float speed)
    {
        _animator.SetFloat(AnimatorData.Params.Speed, Mathf.Abs(speed));       
    }

    public void SetupIsOnGround(bool isOnGround) 
    { 
        _animator.SetBool(AnimatorData.Params.IsGrounded, isOnGround);
    }

    public void SetupAttack()
    {
        _animator.SetTrigger(AnimatorData.Params.Attack);
    }
}