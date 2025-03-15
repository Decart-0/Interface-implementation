using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private T _prefab;

    private Transform[] _places;

    protected void Awake()
    {
        _places = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _spawnPoints.GetChild(i);
        }
    }

    protected void Create()
    {
        for (int i = 0; i < _places.Length; i++)
        {
            Instantiate(_prefab, _places[i].position, Quaternion.identity);
        }
    }
}