using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthFlowingSlider : HealthView
{
    [SerializeField] private float _speed;
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _ownerTransform;
    [SerializeField] private HealthChange _ownerLifeController;
    [SerializeField] private Vector3 _offset;
    [SerializeField] Camera _camera;

    private Coroutine _coroutine;
    private bool _isStartedHealth = true;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.transform.position = _camera.WorldToScreenPoint(_ownerTransform.position + _offset);
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
