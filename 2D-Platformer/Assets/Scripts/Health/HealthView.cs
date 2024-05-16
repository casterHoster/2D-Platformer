using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    public void BuildHealthBar(Health health)
    {
        health.ChangedCount += DrawHealthValue;
        DrawHealthValue(health.CurrentValue, health.MaxValue);
    }

    public void StopDraw(Health health)
    {
        health.ChangedCount -= DrawHealthValue;
        BreakHealthBar();
    }

    protected abstract void BreakHealthBar();

    protected abstract void DrawHealthValue(float currentValue, float maxValue);
}
