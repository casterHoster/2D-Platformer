using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _coin;
    private float _delay;

    private void Start()
    {
        StartCoroutine(Creator());
    }

    private void Awake()
    {
        _delay = 1;
    }

    private Transform GetRandomPoint(Transform[] points)
    {
        Transform point = points[Random.Range(0, points.Length)];
        return point;
    }

    private IEnumerator Creator()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (true)
        {

            
            GameObject gameObject = Instantiate(_coin, GetRandomPoint(_points).position, Quaternion.identity);
            yield return delay;
        }
    }
}
