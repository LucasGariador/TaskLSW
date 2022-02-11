using UnityEngine;

namespace Miscellaneous
{
    
    public class DoorInteract : Interactable
    {
        [SerializeField] private Transform goToInterior;
        private Transform player;

        [SerializeField] private Animator fade;

        [SerializeField] private AudioClip openDoor;
        [SerializeField] private AudioClip closeDoor;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public override void InteractAction()
        {
            audioSource.clip = openDoor;
            audioSource.Play();
            fade.SetTrigger("FadeIn");
            Invoke(nameof(TeleportPlayer), 2f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                player = collision.transform;
            }
        }
        private void TeleportPlayer()
        {
            audioSource.clip = closeDoor;
            audioSource.Play();
            player.position = goToInterior.position;
        }
    }
}