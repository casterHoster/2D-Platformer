using UnityEngine;

public class AttackBase : MonoBehaviour
{
    [SerializeField] private float _attackPower;

    public float AttackPower { get => _attackPower; }
}
