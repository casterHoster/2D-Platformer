using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Health _healthChange;

    private void Start()
    {
        _healthChange = GetComponent<Health>();
        _healthChange.HealthIsNegative += Kill;
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
