using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction<Coin> TookMoney;

    private void OnDestroy()
    {
        TookMoney(this);
    }
}
