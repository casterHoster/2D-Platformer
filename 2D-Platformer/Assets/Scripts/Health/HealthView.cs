using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    public void BuildHealthBar(Health health)
    {
        health.ChangedCount += DrawHealthValue;
        DrawHealthValue(health.CurrentValue, health.MaxValue);
    }

    protected abstract void DrawHealthValue(float currentValue, float maxValue);
}
