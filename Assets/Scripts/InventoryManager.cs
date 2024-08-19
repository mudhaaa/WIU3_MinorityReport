using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public InventorySlot evidenceSlot;
    public GameObject inventoryItemPrefab;
    public int MaxStackedItems = 64;

    [SerializeField] Item testdrugs;
    public bool AddItem(Item item/*, bool QuestCompletion*/)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.ITEM == item && item.Stackable && itemInSlot.count < MaxStackedItems)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot/*, QuestCompletion*/);
                return true;
            }
        }
        return false;
    }
    void SpawnNewItem(Item item, InventorySlot inventorySlot/*, bool QuestCompletion*/)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item/*, QuestCompletion*/);
    }



    public void ClearInventory()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                Destroy(itemInSlot.gameObject);
            }
        }
    }

    private void Start()
    {
        AddItem(testdrugs);
    }
}
