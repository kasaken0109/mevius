using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IinventoryManager : MonoBehaviour
{
    public static IinventoryManager Instance { get; private set; }
    [SerializeField] InventoryGrid inventory;
    [SerializeField] ItemBaseData item;
    public ItemBaseData HaveItem { get; private set; } 
    private void Awake()
    {
        Instance = this;
    }


    public void OnClickGetItem()
    {
        inventory.AddItem(item);
    }

    public void PickUpItem(ItemBaseData item)
    {
        if (!HaveItem)
        {
            HaveItem = item;
        }
    }
    public void PutBackItem()
    {
        if (HaveItem)
        {
            inventory.AddItem(HaveItem);
            HaveItem = null;
        }
    }
}
