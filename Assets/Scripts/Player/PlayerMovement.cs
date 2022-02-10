using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 input;
    Rigidbody2D rb;

    [SerializeField] float playerSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 delta = input;
        rb.velocity = delta * playerSpeed;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        Debug.Log(input);
    }
}
