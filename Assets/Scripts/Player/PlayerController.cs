using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 input;

        private Rigidbody2D rb;

        private Animator _animator;

        [SerializeField, Tooltip("Player speed multiplier.")] private float playerSpeed;

        [SerializeField, Tooltip("Icon above the player when he can interact.")] private GameObject interactionIcon;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            interactionIcon.SetActive(false);
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
}