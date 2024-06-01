using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Death))]

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthViewBase _healthView;

    private HealthSample _health;

    public event UnityAction HealthIsNegative;

    private void Start()
    {
        _health = new HealthSample(_maxHealth);
        _healthView.BuildHealthBar(_health);
    }

    public void IncreaseHealth(float healing)
    {
        _health.Heal(healing);
    }

    public void DecreaseHealth(float damage)
    {
        _health.Damage(damage);
    }

    public float GetCurrentValue()
    {
        return _health.CurrentValue;
    }

    private void Update()
    {
        if (_health.CurrentValue <= 0)
        {
            HealthIsNegative();
            _healthView.StopDraw(_health);
        }
    }
}


