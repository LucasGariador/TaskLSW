using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 input;
        private Rigidbody2D rb;
        private GameObject interactionObj;
        private Animator _animator;

        [HideInInspector] public Sprite frontShirt;
        [HideInInspector] public Sprite backShirt;

        [SerializeField] private SpriteRenderer playerChest;

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
            if(input.y > 0 && rb.velocity.magnitude > 0)
            {
                playerChest.sprite = backShirt;
            }
            else
            {
                playerChest.sprite = frontShirt;
            }
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

        private void OnMove(InputValue value)
        {
            input = value.Get<Vector2>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            interactionIcon.SetActive(true);
            interactionObj = collision.gameObject;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            interactionIcon.SetActive(false);
            interactionObj = null;
        }

        private void OnInteract(InputValue value)
        {
            if(interactionObj != null && interactionIcon.activeSelf == true)
            {
                interactionObj.GetComponent<Interactable>().InteractAction();
                interactionIcon.SetActive(false);
            }
        }
    }
}