using UnityEngine;

public class Collection : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
     _health = GetComponent<Health>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(collision.gameObject);
        }
        else

        if (collision.TryGetComponent(out FirstAidKit firstAidKit) && gameObject.TryGetComponent<PersonMovement>(out PersonMovement personMovement))
        {
            Destroy(collision.gameObject);
            _health.IncreaseHealth(firstAidKit.HealingValue);
        }
    }
}
