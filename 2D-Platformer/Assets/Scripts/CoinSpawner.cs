using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List <Transform> _points;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _generateDelay;
    [SerializeField] private int _maxCoinsCountOnScene;

    private int _coinsCountOnScene;

    private void Start()
    {
        StartCoroutine(Creator());
    }

    private void Awake()
    {
        _coinsCountOnScene = 0;
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
        WaitForSeconds delay = new WaitForSeconds(_generateDelay);
        
        while (true)
        {
            if (_maxCoinsCountOnScene > _coinsCountOnScene)
            {
                Coin coin = Instantiate(_coin, GetRandomPoint(_points).position, Quaternion.identity);
                coin.tookMoney += SubtractCoinsCountOnScene;
                _coinsCountOnScene++;
            }

            yield return delay;
        }
    }
}
