using System;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction tookMoney;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement movement))
        {
            Destroy(gameObject);
            tookMoney?.Invoke();
        }
    }
}
