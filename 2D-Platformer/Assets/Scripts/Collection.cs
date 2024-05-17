using UnityEngine;

public class Collection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);
        }
        else

        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            Destroy(collision.gameObject);
        }
    }
}
