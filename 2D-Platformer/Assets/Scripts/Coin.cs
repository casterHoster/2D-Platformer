using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action tookMoney;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement movement))
        {
            tookMoney?.Invoke();
            Destroy(gameObject);
        }
    }
}
