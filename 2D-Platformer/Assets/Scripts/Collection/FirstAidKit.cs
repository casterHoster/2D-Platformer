using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private float _healingValue;

    public FirstAidKit()
    {
        _healingValue = 1f;
    }
    public float HealingValue { get => _healingValue; }
}