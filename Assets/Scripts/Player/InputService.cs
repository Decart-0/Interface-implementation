using UnityEngine;

[RequireComponent(typeof(InputScheme))]
public class InputService : MonoBehaviour
{
    private InputScheme _inputScheme;

    private void Awake()
    {
        _inputScheme = GetComponent<InputScheme>();
    }

    public float GetMovementInput() 
    {
        return Input.GetAxis(_inputScheme.AxisHorizontal); ;
    }

    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(_inputScheme.Jump);
    }

    public bool IsAttackPressed()
    {
        return Input.GetKeyDown(_inputScheme.Attack);
    }
}