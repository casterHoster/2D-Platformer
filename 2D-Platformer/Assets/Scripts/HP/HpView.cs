using UnityEngine;

public abstract class HpView : MonoBehaviour
{
    public void Construct(HP hp)
    {
        hp.OnHpChanged += DrawValue;
        DrawValue(hp.Current, hp.Max);
    }

    protected abstract void DrawValue(float current, float max);
}
