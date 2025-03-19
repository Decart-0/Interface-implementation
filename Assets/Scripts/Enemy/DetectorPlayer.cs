using System;
using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    public event Action PlayerSeeing;

    public bool IsPlayerVisible { get; private set; }

    public Health HealthPlayer { get; private set; }

    private void Awake()
    {
        IsPlayerVisible = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {     
        if (collider.TryGetComponent(out Player player))
        {
            HealthPlayer = player.GetComponent<Health>();
            IsPlayerVisible = true;
            PlayerSeeing?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
           IsPlayerVisible = false;
           PlayerSeeing?.Invoke();
        }
    }
}