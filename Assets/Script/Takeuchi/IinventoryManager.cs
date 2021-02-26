using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IinventoryManager : MonoBehaviour
{
    List<ItemBaseData> haveItems;
    [SerializeField] InventoryGrid inventory;
    [SerializeField] ItemBaseData item;
    private void Awake()
    {
        haveItems = new List<ItemBaseData>();
    }

    public void AddItem(ItemBaseData item)
    {
        haveItems.Add(item);
    }

    public void OnClickGetItem()
    {
        inventory.AddItem(item);
    }
}
