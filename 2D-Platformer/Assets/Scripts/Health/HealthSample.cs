using UnityEngine;
using UnityEngine.Events;

public class HealthSample
{
    private float _maxValue;
    private float _currentValue;

    public event UnityAction<float, float> ChangedCount;
    
    public float MaxValue { get => _maxValue; }

    public float CurrentValue { get => _currentValue; }

    public HealthSample(float maxHealth)
    {
        _currentValue = maxHealth;
        _maxValue = maxHealth;
    }

    public void Damage(float damage)
    {
        _currentValue -= damage;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
        ChangedCount?.Invoke(_currentValue, _maxValue);
    }

    public void Heal(float healing)
    {
        _currentValue += healing;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
        ChangedCount?.Invoke(_currentValue, _maxValue);
    }
}








































