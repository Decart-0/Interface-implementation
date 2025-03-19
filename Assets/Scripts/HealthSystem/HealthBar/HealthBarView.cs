using UnityEngine;

public abstract class HealthBarView<T> : MonoBehaviour
{   
    [SerializeField] protected Health Health;
    [SerializeField] protected T Bar;

    private void OnEnable()
    {
        Health.Changed += ChangeHealth;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        Health.Changed -= ChangeHealth;
    }

    protected virtual void ChangeHealth() {}
}