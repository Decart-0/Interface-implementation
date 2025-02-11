using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSmoothView : HealthBarView<Slider>
{
    [SerializeField] private float _smoothSpeed;

    private Coroutine _updateSmoothly;

    private void Awake()
    {
        Bar.maxValue = Health.MaxValue;
        Bar.value = Health.Value;
    }

    private void OnDestroy()
    {
        if (_updateSmoothly != null)
        {
            StopCoroutine(_updateSmoothly);
        }
    }

    protected override void ChangeHealth()
    {
        if (_updateSmoothly != null)
        {
            StopCoroutine(_updateSmoothly);
        }

        _updateSmoothly = StartCoroutine(UpdateSmoothly());
    }

    private IEnumerator UpdateSmoothly() 
    { 
        while (true) 
        {
            Bar.value = Mathf.MoveTowards(Bar.value, Health.Value, _smoothSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
}