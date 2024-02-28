using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radiusTestingGround;
    [SerializeField] private Transform pointForTestGround;

    private Rigidbody2D _body;
    private bool isOnGround;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isOnGround = Physics2D.OverlapCircle(pointForTestGround.position, _radiusTestingGround, _ground);

        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            _body.AddForce(Vector2.up * _jumpForce);
        }
    }
}
