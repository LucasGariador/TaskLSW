using UnityEngine;
namespace Core {
    public class ThisItem : MonoBehaviour
    {
        private SellItem sellItem;
        //    [HideInInspector]
        public InventoryObjects thisObj;

        public bool isPlayer;
        private void Start()
        {
            sellItem = GetComponentInParent<SellItem>();
        }
        public void ToSell()
        {
            if (!isPlayer)
            {
                sellItem.SellObject(thisObj);
            }
            else
            {
                sellItem.PlayerSellObject(thisObj);
                Destroy(gameObject, .2f);
            }
        }
    }
}