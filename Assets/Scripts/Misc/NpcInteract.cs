using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class NpcInteract : Interactable
    {
        private PlayerInventory playerInventory;

        [SerializeField] private List<InventoryObjects> storeContainer = new List<InventoryObjects>();
        [SerializeField] private GameObject prefabSlot;
        [SerializeField] private GameObject storeGrid;
        [SerializeField] private GameObject store;
        public override void InteractAction()
        {
            // start Dialogue
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
        }

        public void OpenStore()
        {

        }

        public void AddObject(InventoryObjects newObject)
        {
            storeContainer.Add(newObject);
            var newInstObj = Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, inventoryGrid.transform);
        }
    }
}