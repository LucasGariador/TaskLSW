using UnityEngine;

namespace Core
{
    public class SellItem : MonoBehaviour
    {
        [SerializeField] private NpcInteract npcInteract;
        [SerializeField] private PlayerInventory playerInventory;

        public void SellObject(InventoryObjects inventoryObjects)
        {
            npcInteract.SellObject(inventoryObjects);
        }

        public void PlayerSellObject(InventoryObjects inventoryObjects)
        {
            playerInventory.SellPlayerItem(inventoryObjects);
        }
    }
}