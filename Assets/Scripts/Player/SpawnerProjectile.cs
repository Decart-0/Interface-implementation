using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputService))]
public class SpawnerProjectile : Spawner<Vampirism>
{
    private float _time;
    private bool _isVampirismActive = false;
    private WaitForSeconds _waitInterval;
    private InputService _inputService;
    private Coroutine _coroutine;

    public event Action<float> Changed;

    protected void Awake()
    {
        base.Awake();
        _inputService = GetComponent<InputService>();
        _waitInterval = new WaitForSeconds(Prefab.TimeInterval);
        _time = Prefab.TimeCoolddown;
    }

    private void OnEnable()
    {
        _inputService.VampirismPressed += StartVampirism;
    }

    private void OnDisable()
    {
        _inputService.VampirismPressed -= StartVampirism;
    }

    protected override void Create()
    {
        for (int i = 0; i < Places.Length; i++)
        {
            var prefab = Instantiate(Prefab, Places[i].position, Quaternion.identity);
            prefab.OnDestroyed += VampirismDestroyed;
            _isVampirismActive = true;
            
            if (SpawnPoints != null)
            {
                prefab.transform.SetParent(SpawnPoints);
            }
            else
            {

                prefab.transform.SetParent(null);
            }
        }
        
    }

    private void VampirismDestroyed()
    {
        _coroutine = StartCoroutine(WaitÑoolddown());
        _isVampirismActive = false;
    }

    private void StartVampirism() 
    {
        if (_isVampirismActive == false && _coroutine == null)
        {
            Create();
        }
    }

    private IEnumerator WaitÑoolddown()
    {
        while (_time > 0) 
        {
            _time--;
            Changed?.Invoke(_time);

            yield return _waitInterval;
        }   

        _coroutine = null;
        _time = Prefab.TimeCoolddown;
        Changed?.Invoke(_time);
    }
}