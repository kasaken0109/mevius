using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class IinventoryManager : MonoBehaviour
{
    public static IinventoryManager Instance { get; private set; }
    [SerializeField] InventoryGrid inventory;
    [SerializeField] ItemBaseData item;
    [SerializeField] RecycleMachine recycleMachine;
    public ItemBaseData HaveItem { get; private set; }
    public bool recycleMode;
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
    public void RecycleItem()
    {
        if (HaveItem)
        {
            recycleMachine.DropMaterial(HaveItem.HaveMaterials);
            HaveItem = null;
        }
    }
    public GameObject GetRecycle(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        var result = results.Where(x => x.gameObject.CompareTag("Recycle")).FirstOrDefault();
        return result.gameObject;
    }
}
