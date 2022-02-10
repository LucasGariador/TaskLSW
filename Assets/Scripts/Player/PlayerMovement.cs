using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 input;

    Rigidbody2D rb;
    Animator _animator;

    [SerializeField] float playerSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        _animator.SetFloat("VerticalMov", input.y);
        _animator.SetFloat("Velocity", rb.velocity.magnitude);
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
