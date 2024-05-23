using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthFlowingSlider : HealthViewBase
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Transform _ownerTransform;
    [SerializeField] protected HealthChange _ownerLifeController;
    [SerializeField] protected Vector3 _offset;

    private Coroutine _coroutine;
    private bool _isStartedHealth = true;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void DrawHealthValue(float currentValue, float maxValue)
    {
        _slider.maxValue = maxValue;

        if (_isStartedHealth)
        {
            _slider.value = currentValue;
            _isStartedHealth = false;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(FlowCurrentDraw(currentValue));          
    }

    protected override void BreakHealthBar()
    {
        Destroy(gameObject);
    }

    private IEnumerator FlowCurrentDraw(float currentValue)
    {
        while (_slider.value != currentValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime * _speed);
            yield return null;
        }
    }
}
