using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ScannerEnemie))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _timeWork = 6f;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private Health _playerHealth;

    private WaitForSeconds _waitInterval;
    private ScannerEnemie _scannerEnemie;

    [field:SerializeField] public float TimeInterval { get; private set; } = 1f;

    [field: SerializeField] public float TimeCoolddown { get; private set; } = 4f;

    public event Action OnDestroyed;

    private void Start()
    {
        _waitInterval = new WaitForSeconds(TimeInterval);
        _scannerEnemie = GetComponent<ScannerEnemie>();
        StartCoroutine(Work());
    }

    private void Die()
    {
        OnDestroyed?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator Work() 
    {
        for (int i = 0; i < _timeWork; i++)
        {
            Ghost nearestGhost = _scannerEnemie.FindNearestGhost(transform.position);

            if (nearestGhost != null)
            {
                nearestGhost.TakeDamage(_damage);
                _playerHealth.Restore(_damage);
            }

            yield return _waitInterval;
        }

        Die();
    }
}