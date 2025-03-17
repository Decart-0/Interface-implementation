using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform SpawnPoints;
    [SerializeField] protected T Prefab;

    protected Transform[] Places;

    protected void Awake()
    {
        Places = new Transform[SpawnPoints.childCount];

        for (int i = 0; i < Places.Length; i++)
        {
            Places[i] = SpawnPoints.GetChild(i);
        }
    }

    protected virtual void Create()
    {
        for (int i = 0; i < Places.Length; i++)
        {
            var prefab = Instantiate(Prefab, Places[i].position, Quaternion.identity);

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
}