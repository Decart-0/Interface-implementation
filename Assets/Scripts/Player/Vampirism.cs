using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _distance = 1f;
    [SerializeField] private float _timeInterval = 1f;
    [SerializeField] private float _intervalWork = 1f;
    [SerializeField] private float _timeDuration = 2f;
    [SerializeField] private float _timeWork = 6f;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _scaleMultiplier = 2f;
    [SerializeField] private float _initialDelay = 0.1f;

    [SerializeField] private Transform _player;

    private void Start()
    {
        StartCoroutine(WaitWork());
    }

    private void Die()
    {
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
                }
            }

            yield return new WaitForSeconds(_intervalWork);
        }

        Die();
    }
}