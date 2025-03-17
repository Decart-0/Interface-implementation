using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _timeWork = 6f;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private Health _playerHealth;

    private WaitForSeconds _waitInterval;

    [field:SerializeField] public float TimeInterval { get; private set; } = 1f;

    [field: SerializeField] public float TimeCoolddown { get; private set; } = 4f;

    public event Action OnDestroyed;

    private void Start()
    {
        _waitInterval = new WaitForSeconds(TimeInterval);
        StartCoroutine(WaitWork());
    }

    private void Die()
    {
        OnDestroyed?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator WaitWork() 
    {
        for (int i = 0; i < _timeWork; i++)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Ghost ghost))
                {
                    ghost.TakeDamage(_damage);
                    _playerHealth.Restore(_damage);
                }
            }

            yield return _waitInterval;
        }

        Die();
    }
}