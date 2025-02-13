using System;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [field: SerializeField] public float MaxValue { get; private set; }

    [field: SerializeField] public float Value { get; private set; }

    public event Action Changed;

    public void Restore(float amount)
    {
        if (amount > 0) 
        {
            Value = Mathf.Min(Value + amount, MaxValue);
            Changed?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0) 
        {
            Value = Mathf.Max(Value - damage, 0);
            Changed?.Invoke();
        }
    }
}