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

    protected void Start()
    {
        _time = _timeCoolddown;
    }

    private void Update()
    {
        if(_inputService.IsVampirismPressed() && _coroutine == null) 
        {
            Create();
            _coroutine = StartCoroutine(Wai�oolddown());
        }
    }

    private IEnumerator Wai�oolddown()
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