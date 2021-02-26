using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemBaseData Item { get; private set; }
    [SerializeField] Image itemImage;

    public void SetItem(ItemBaseData item)
    {
        Item = item;
        if (Item)
        {
            itemImage.sprite = item.ItemImage;
        }
    }
}
