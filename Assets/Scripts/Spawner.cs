using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [field:SerializeField] protected T _prefab { get; private set; }

    protected Transform[] _places { get; private set; }

    protected void Awake()
    {
        _places = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _spawnPoints.GetChild(i);
        }
    }

    protected virtual void Create()
    {
        for (int i = 0; i < _places.Length; i++)
        {
            Instantiate(_prefab, _places[i].position, Quaternion.identity);
        }
    }
}