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
        if (dragItem)
        {
            Destroy(dragItem);
        }
        if (IinventoryManager.Instance.GetRecycle(eventData))
        {
            Item = null;
            IinventoryManager.Instance.RecycleItem();
        }
        else if(IinventoryManager.Instance.GetRecycleO(eventData))
        {
            if (Player.Instance.obstacle)
            {
                Player.Instance.obstacle.BreakObstacle(Item.type);
            }
            Item = null;
            IinventoryManager.Instance.PutBackItem();
        }
        else if (IinventoryManager.Instance.GetRecycleT(eventData))
        {
            if (Player.Instance.timeMachine)
            {
                if (Item.type == CommandType.GetTimeParts)
                {
                    Player.Instance.timeMachine.Message();
                }
            }
            Item = null;
            IinventoryManager.Instance.PutBackItem();
        }
        else
        {
            Item = null;
            IinventoryManager.Instance.PutBackItem();
        }
        
    }
}
