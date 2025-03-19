using UnityEngine;
using UnityEngine.UI;

public class CooldownBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private SpawnerProjectile _spawnerProjectile;
    [SerializeField] private float _timeCooldown = 4f;

    private void Start()
    {
        _slider.maxValue = _timeCooldown;
        _slider.value = _slider.maxValue;
    }

    private void OnEnable()
    {
        _spawnerProjectile.Changed += UpdateCooldown;
    }

    private void OnDisable()
    {
        _spawnerProjectile.Changed -= UpdateCooldown;
    }

    private void UpdateCooldown(float time)
    {
        _slider.value = time;
    }
}
