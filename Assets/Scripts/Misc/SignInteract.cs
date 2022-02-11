using UnityEngine;
using TMPro;

namespace Miscellaneous
{
    public class SignInteract : Interactable
    {
        [SerializeField] private string signText = "";
        [SerializeField] private GameObject dialogeField;
        private TMP_Text text;

        public override void InteractAction()
        {
            dialogeField.SetActive(true);
            text = dialogeField.GetComponentInChildren<TMP_Text>();
            text.text = signText;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                dialogeField.SetActive(false);
            }
        }
    }

}