using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List <Transform> _points;
    [SerializeField] private Coin _coin;

    private float _delay;
    private int _maxCoinsCountOnScene;
    private int _coinsCountOnScene;
    private List<Coin> _coins;

    private void Start()
    {
        StartCoroutine(Creator());
    }

    private void Awake()
    {
        _delay = 5;
        _maxCoinsCountOnScene = 2;
        _coinsCountOnScene = 0;
    }

    private void OnEnable()
    {
        
    }

    private void SubtractCoinsCountOnScene()
    {
        if (_coinsCountOnScene >= 0) 
        {
            _coinsCountOnScene--;
        }
    }

    private Transform GetRandomPoint(List <Transform> points)
    {
        Transform point = _points[Random.Range(0, points.Count)];
        return point;
    }

    private IEnumerator Creator()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        
        while (true)
        {
            if (_maxCoinsCountOnScene > _coinsCountOnScene)
            {
                Coin coin = Instantiate(_coin, GetRandomPoint(_points).position, Quaternion.identity);
                _coins.Add(coin);
                _coinsCountOnScene++;
            }

            yield return delay;
        }
    }
}
