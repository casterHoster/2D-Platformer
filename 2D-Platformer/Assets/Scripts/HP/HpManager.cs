using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    private HP _hp;

    [SerializeField] float _max;

    [SerializeField] List<HpView> _views = new List<HpView>();

    [SerializeField] Button _decrease, _increase;

    private void Start()
    {
        var hp = new HP(_max);
        _hp = hp;

        foreach (var view in _views)
            view.Construct(hp);

        _decrease.onClick.AddListener(SetDamage);
        _increase.onClick.AddListener(Heal);
    }

    private void Heal() => _hp.Heal(10);

    private void SetDamage() => _hp.SetDamage(10);

}
