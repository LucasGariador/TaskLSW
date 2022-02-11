using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryObjects> Container = new List<InventoryObjects>();
    [SerializeField] private GameObject prefabSlot;
    [SerializeField] private GameObject inventoryGrid;
    [SerializeField] private GameObject inventory;

    private void Start()
    {
        inventory.SetActive(false);
    }
    public void AddObject(InventoryObjects newObject)
    {
        Container.Add(newObject);
        var newInstObj = Instantiate(prefabSlot, Vector3.zero, Quaternion.identity,inventoryGrid.transform);
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
}
