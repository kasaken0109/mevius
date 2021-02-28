using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] GameObject itemSlotPrefab;
    [SerializeField] int slotNumgber = 8;
    [SerializeField] ItemBaseData[] AllItems;
    public List<ItemSlot> ItemSlots { get; private set; }
    void Start()
    {
        ItemSlots = new List<ItemSlot>();
        for (int i = 0; i < slotNumgber; i++)
        {
            GameObject slot = Instantiate(itemSlotPrefab, this.transform);
            ItemSlot slotData = slot.GetComponent<ItemSlot>();
            if (i < AllItems.Length)
            {
                slotData.SetItem(AllItems[i]);
            }
            else
            {
                slotData.SetItem(null);
            }
            ItemSlots.Add(slotData);
        }
    }
    
    public bool AddItemCheck()
    {
        foreach (var item in ItemSlots)
        {
            if (!item)
            {
                return true;
            }
        }
        return false;
    }
    public void AddItem(ItemBaseData item)
    {
        ItemSlot slot = ItemSlots.Where(i => i.Item == null).FirstOrDefault();
        if (slot)
        {
            slot.SetItem(item);
        }
    }
}
