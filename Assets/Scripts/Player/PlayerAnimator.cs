using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRun(float speed)
    {
        _animator.SetFloat(AnimatorData.Params.Speed, Mathf.Abs(speed));       
    }

    public void PlayJump(bool isOnGround) 
    { 
        _animator.SetBool(AnimatorData.Params.IsGrounded, isOnGround);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(AnimatorData.Params.Attack);
    }
}