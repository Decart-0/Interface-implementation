using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DetectorPlayer))]
[RequireComponent(typeof(GhostAnimator))]
[RequireComponent(typeof(Health))]
public class Ghost : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldownAttack;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _playerLayer;

    private DetectorPlayer _detectorPlayer;
    private Health _health;
    private GhostAnimator _animator;
    private Coroutine _attackCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _detectorPlayer = GetComponent<DetectorPlayer>();
        _health = GetComponent<Health>();
        _animator = GetComponent<GhostAnimator>();
        _waitForSeconds = new WaitForSeconds(_cooldownAttack);
    }

    private void OnEnable()
    {
        _health.Changed += CheckHealth;
    }

    private void Update()
    {      
        if (_detectorPlayer.IsPlayerVisible)
            UpdateAttackState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPosition.position, _attackRadius);
    }

    private void OnDisable()
    {
        _health.Changed -= CheckHealth;
    }

    public void TakeDamage(float damage)
    {
       _health.TakeDamage(damage);
    }

    private void UpdateAttackState()
    {
        if (Physics2D.OverlapCircle(_attackPosition.position, _attackRadius, _playerLayer))
        {   
            StartAttack();           
        }
        else
        {
            StopAttack();
        }
    }

    private void StartAttack()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(WaitAttack());
        }
    }

    private void StopAttack()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null; 
        }
    }

    private void CheckHealth()
    {
        if (_health.Value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StopAttack();
        Destroy(gameObject);
    }

    private IEnumerator WaitAttack()
    {
        while (true)
        {
            _animator.PlayAttackAnimation();
            _detectorPlayer.HealthPlayer.TakeDamage(_damage);

            yield return _waitForSeconds;
        }
    }
}