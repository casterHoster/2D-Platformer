using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    public event UnityAction<KeyCode> KeyPassed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KeyPassed?.Invoke(KeyCode.Space);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyPassed?.Invoke(KeyCode.E);
        }

        if (Input.GetKey(KeyCode.A))
        {
            KeyPassed?.Invoke(KeyCode.A);
        }

        if (Input.GetKey(KeyCode.D))
        {
            KeyPassed?.Invoke(KeyCode.D);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            KeyPassed?.Invoke(KeyCode.W);
        }
    }                                                                                                                                                          
}
