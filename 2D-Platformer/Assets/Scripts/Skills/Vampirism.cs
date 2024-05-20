using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
[RequireComponent (typeof(Health))]

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _range;

    private Skill _skill;
    private CircleCollider2D _circleSkillRadius;
    private Health _personHealth;

    private void Start()
    {
        _skill = new Skill(_range);
        _circleSkillRadius = new CircleCollider2D();
        _circleSkillRadius.radius = _range;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            
        }
    }

    private void DrinkHealth(Health enemyHealth)
    {
        _personHealth.Heal();
        enemyHealth.Damage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
