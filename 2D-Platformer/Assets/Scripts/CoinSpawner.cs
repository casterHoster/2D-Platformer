using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _generateDelay;
    [SerializeField] private int _maxCoinsCountOnScene;

    private List<Coin> _coins;
    private List<Vector3> _pointsVectors;

    private void Start()
    {
        ConvertToVectors();
        StartCoroutine(Creator());
    }

    private void Awake()
    {
        _pointsVectors = new List<Vector3>();
        _coins = new List<Coin>();
    }

    private void DecreaseCount(Coin coin)
    {
        if (_coins.Count >= 0)
        {
            _pointsVectors.Add(coin.transform.position);
            _coins.Remove(coin);
        }
    }

    private void ConvertToVectors()
    {
        for (int i =  0; i < _points.Count; i++)
        {
            _pointsVectors.Add(_points[i].position);
        }
    }

    private Vector3 GetRandomPoint(List<Vector3> points)
    {
        Vector3 point = _pointsVectors[Random.Range(0, points.Count)];
        return point;
    }

    private IEnumerator Creator()
    {
        WaitForSeconds delay = new WaitForSeconds(_generateDelay);

        while (true)
        {
            if (_maxCoinsCountOnScene > _coins.Count)
            {
                Vector3 currentTransform = GetRandomPoint(_pointsVectors);
                Coin coin = Instantiate(_coin, currentTransform, Quaternion.identity);
                _coins.Add(coin);
                _pointsVectors.Remove(currentTransform);
                coin.TookMoney += DecreaseCount;
            }

            yield return delay;
        }
    }
}
