using UnityEngine;
using UnityEngine.Events;

public class Health
{
    private float _maxValue;
    private float _currentValue;

    public float MaxValue { get => _maxValue; }

    public float CurrentValue { get => _currentValue; }

    public event UnityAction<float, float> ChangedCount;

    public Health(float maxHealth)
    {
        _currentValue = maxHealth;
        _maxValue = maxHealth;
    }

    public void Damage()
    {
        _currentValue --;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
        ChangedCount?.Invoke(_currentValue, _maxValue);
    }

    public void Heal()
    {
        _currentValue++;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
        ChangedCount?.Invoke(_currentValue, _maxValue);
    }
}

