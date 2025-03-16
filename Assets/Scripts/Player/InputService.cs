using System;
using UnityEngine;

[RequireComponent(typeof(InputScheme))]
public class InputService : MonoBehaviour
{
    private InputScheme _inputScheme;

    public event Action JumpPressed;
    public event Action HitPressed;
    public event Action VampirismPressed;

    private void Awake()
    {
        _inputScheme = GetComponent<InputScheme>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_inputScheme.Jump))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(_inputScheme.Hit))
        {
            HitPressed?.Invoke();
        }

        if (Input.GetKeyDown(_inputScheme.Vampirism))
        {
            VampirismPressed?.Invoke();
        }
    }

    public float GetMovementInput()
    {
        return Input.GetAxis(_inputScheme.AxisHorizontal); ;
    }
}