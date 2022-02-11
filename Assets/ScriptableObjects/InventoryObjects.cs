using UnityEngine;
[CreateAssetMenu(fileName = "New Outfit", menuName = "InventorySystem/Shirt")]
public class InventoryObjects : ScriptableObject
{
    public Sprite front;
    public Sprite back;
    public int buyPrice;
    public int sellPrice;
    public string description;
}