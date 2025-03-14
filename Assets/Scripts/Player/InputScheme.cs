using UnityEngine;

public class InputScheme : MonoBehaviour
{
    [field: SerializeField] public KeyCode Jump { get; private set; } = KeyCode.Space;

    [field: SerializeField] public KeyCode Attack { get; private set; } = KeyCode.Mouse0;

    public string AxisHorizontal { get; private set; }

    private void Awake()
    {
        AxisHorizontal = "Horizontal";
    }
}