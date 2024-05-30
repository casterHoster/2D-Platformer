using UnityEngine;

public abstract class HealthViewBase : MonoBehaviour
{
    public void BuildHealthBar(HealthSample health)
    {
        health.ChangedCount += DrawHealthValue;
        DrawHealthValue(health.CurrentValue, health.MaxValue);
    }

    public void StopDraw(HealthSample health)
    {
        health.ChangedCount -= DrawHealthValue;
        BreakHealthBar();
    }

    protected abstract void BreakHealthBar();

    protected abstract void DrawHealthValue(float currentValue, float maxValue);
}
