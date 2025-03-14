using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class ItemCollector : MonoBehaviour
{
    private Wallet _wallet;
    private Health _healthPlayer;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _healthPlayer = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IPickupable iPickupable))
        {
            Pickup(iPickupable);
        }
    }

    private void Pickup(IPickupable iPickupable)
    {
        var visitor = new PickupVisitor(_healthPlayer, _wallet);
        iPickupable.Accept(visitor);
    }
}