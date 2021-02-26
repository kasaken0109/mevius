using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IinventoryManager : MonoBehaviour
{
    List<ItemBase> haveItems;
    private void Awake()
    {
        haveItems = new List<ItemBase>();
    }

    public void AddItem(ItemBase item)
    {
        haveItems.Add(item);
    }

}
