using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Player;

namespace Core
{

    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private List<InventoryObjects> Container = new List<InventoryObjects>();
        [SerializeField] private GameObject prefabSlot;
        [SerializeField] private GameObject inventoryGrid;
        [SerializeField] private GameObject inventory;

        [SerializeField] private TMP_Text coinAmount;

        private PlayerController playerController;
        public InventoryObjects equiped;
        public int coin = 7;

        [SerializeField] private AudioClip positiveSound;
        [SerializeField] private AudioClip negativeSound;
        private AudioSource audioSource;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
 
        }
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            inventory.SetActive(false);
            coinAmount.text = Convert.ToString(coin);

            equiped = Container[0];
            Equipping();
        }
        public void AddObject(InventoryObjects newObject)
        {
            coin -= newObject.buyPrice;
            coinAmount.text = Convert.ToString(coin);
            Container.Add(newObject);
            var newInstObj = Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, inventoryGrid.transform);
            newInstObj.GetComponent<ThisItem>().thisObj = newObject;
            newInstObj.GetComponent<ThisItem>().isPlayer = true;

            DisplayObject(newInstObj, newObject);
            equiped = newObject;
            Equipping();
        }

        private void OnOpenInventory(InputValue value)
        {
            if (inventory.activeSelf == false)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }

        private void Equipping()
        {
            playerController.frontShirt = equiped.front;
            playerController.backShirt = equiped.back;
        }

        private void DisplayObject(GameObject newInstObj, InventoryObjects newObject)
        {
            newInstObj.GetComponentInChildren<Image>().sprite = newObject.front;
            newInstObj.GetComponentInChildren<TMP_Text>().text = newObject.name;
            newInstObj.GetComponentInChildren<Text>().text = newObject.sellPrice.ToString();
        }

        public void SellPlayerItem(InventoryObjects removeObject)
        {
            if (Container.Count > 1)
            {
                Container.Remove(removeObject);

                coin += removeObject.sellPrice;
                coinAmount.text = Convert.ToString(coin);

                equiped = Container[0];
                Equipping();

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