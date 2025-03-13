using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    private const float AngleRight = 0f;
    private const float AngleLeft = 180f;

    public void Flip(float direction)
    {
        float targetAngle = direction > 0 ? AngleRight : AngleLeft;
        transform.rotation = Quaternion.Euler(new Vector2(0, targetAngle));
    }
}