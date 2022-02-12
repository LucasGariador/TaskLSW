using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core
{
    public class NpcInteract : Interactable
    {
        private PlayerInventory playerInventory;
        private bool firstTime = true;
        [SerializeField] private List<InventoryObjects> storeContainer = new List<InventoryObjects>();
        [SerializeField] private GameObject prefabSlot;
        [SerializeField] private GameObject storeGrid;
        [SerializeField] private GameObject store;

        [SerializeField] private AudioClip positiveSound;
        [SerializeField] private AudioClip negativeSound;
        private AudioSource audioSource;

        [SerializeField] GameObject dialogue;
        [SerializeField] string welcomeDialogue = "";
        public override void InteractAction()
        {
            dialogue.SetActive(true);
            dialogue.GetComponentInChildren<TMP_Text>().text = welcomeDialogue;
            Invoke(nameof(OpenStore),3f);
        }
        private void Start()
        {
            foreach(InventoryObjects obj in storeContainer)
            {
                AddObject(obj);
            }
            store.SetActive(false);
            firstTime = false;
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
        }

        public void OpenStore()
        {
            store.SetActive(true);
            dialogue.SetActive(false);
        }

        public void AddObject(InventoryObjects newObject)
        {
            if (!firstTime)
            {
                storeContainer.Add(newObject);
            }
            var newInstObj = Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, storeGrid.transform);
            newInstObj.GetComponent<ThisItem>().thisObj = newObject;

            DisplayObject(newInstObj, newObject);
        }

        private void DisplayObject(GameObject newInstObj, InventoryObjects newObject)
        {
            newInstObj.GetComponentInChildren<Image>().sprite = newObject.front;
            newInstObj.GetComponentInChildren<TMP_Text>().text = newObject.name;
            newInstObj.GetComponentInChildren<Text>().text = newObject.buyPrice.ToString();

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            store.SetActive(false);
        }

        public void SellObject(InventoryObjects removeObject)
        {
            if (playerInventory.coin >= removeObject.buyPrice)
            {
                playerInventory.AddObject(removeObject);
                storeContainer.Remove(removeObject);

                audioSource.clip = positiveSound;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = negativeSound;
                audioSource.Play();
            }
        }
    }
}