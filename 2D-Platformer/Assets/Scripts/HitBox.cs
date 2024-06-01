using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private AttackBase _attack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.DecreaseHealth(_attack.AttackPower);
        }
    }
}
