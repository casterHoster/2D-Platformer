using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private HealthChange _healthChange;

    private void Start()
    {
        _healthChange = GetComponent<HealthChange>();
        _healthChange.HealthIsNegative += Kill;
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
