using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemBaseData Item { get; private set; }
    [SerializeField] Image itemImage;
    GameObject dragItem;
    [SerializeField]
    GameObject itemObject;
    Transform canvasTransform;
    private void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
    }
    public void SetItem(ItemBaseData item)
    {
        Item = item;
        if (Item)
        {
            itemImage.sprite = item.ItemImage;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!Item)
        {
            return;
        }
        dragItem = Instantiate(itemObject, canvasTransform);
        dragItem.transform.SetAsLastSibling();
        IinventoryManager.Instance.PickUpItem(Item);       
        itemImage.sprite = null;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!Item)
        {
            return;
        }
        dragItem.transform.position = eventData.position;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Item = null;
        if (dragItem)
        {
            Destroy(dragItem);
        }
        IinventoryManager.Instance.PutBackItem();
    }
}
