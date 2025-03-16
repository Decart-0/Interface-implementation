using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputService))]
public class SpawnerProjectile : Spawner<Vampirism>
{
    [SerializeField] private float _timeCoolddown = 4f;
    [SerializeField] private float _timeInterval = 1f;

    private float _time;
    private InputService _inputService;
    private Coroutine _coroutine;

    public event Action<float> Changed;

    protected void Awake()
    {
        base.Awake();
        _inputService = GetComponent<InputService>();
    }

    private void OnEnable()
    {
        _inputService.VampirismPressed += StartVampirism;
    }

    protected void Start()
    {
        _time = _timeCoolddown;
    }

    private void OnDisable()
    {
        _inputService.VampirismPressed -= StartVampirism;
    }

    private void StartVampirism() 
    {
        if (_coroutine == null) 
        { 
            Create();
            _coroutine = StartCoroutine(WaiÑoolddown());
        }
    }

    private IEnumerator WaiÑoolddown()
    {
        WaitForSeconds waitInterval = new WaitForSeconds(_timeInterval);

        while (_time > 0) 
        {
            _time--;
            Changed?.Invoke(_time);

            yield return waitInterval;
        }   

        _coroutine = null;
        _time = _timeCoolddown;
        Changed?.Invoke(_time);
    }
}