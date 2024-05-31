using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Death))]

public class HealthChange : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthViewBase _healthView;

    private HealthSample _health;

    //public event UnityAction<float, float> HealthChanged;
    public event UnityAction HealthIsNegative;

    private void Start()
    {
        _health = new HealthSample(_maxHealth);
        _healthView.BuildHealthBar(_health);
    }

    public void IncreaseHealth()
    {
        _health.Heal();
    }

    public void DecreaseHealth()
    {
        _health.Damage();

        if (_health.CurrentValue <= 0)
        {
            Destroy(gameObject);
            _healthView.StopDraw(_health);
        }
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

        //HealthChanged?.Invoke(_health.CurrentValue, _health.MaxValue);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out FirstAidKit firstaidkit) && gameObject.TryGetComponent<PersonMovement>(out PersonMovement personMovement))
    //    {
    //        _health.Heal();
    //        //HealthChanged?.Invoke(_health.CurrentValue, _health.MaxValue);
    //    }
    //}
}


