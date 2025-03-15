using UnityEngine;

public class InputScheme : MonoBehaviour
{
    [field: SerializeField] public KeyCode Jump { get; private set; } = KeyCode.Space;

    [field: SerializeField] public KeyCode Hit { get; private set; } = KeyCode.Mouse0;

    [field: SerializeField] public KeyCode Vampirism { get; private set; } = KeyCode.Mouse1;

    public string AxisHorizontal { get; private set; }

    private void Awake()
    {
        AxisHorizontal = "Horizontal";
    }
}