﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class IinventoryManager : MonoBehaviour
{
    public static IinventoryManager Instance { get; private set; }
    [SerializeField] InventoryGrid inventory;
    [SerializeField] ItemBaseData item;
    [SerializeField] ItemBaseData[] allItems;
    [SerializeField] RecycleMachine recycleMachine;
    public ItemBaseData HaveItem { get; private set; }
    public bool recycleMode;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
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
            if (!recycleMachine)
            {
                recycleMachine = GameObject.Find("再生機").GetComponent<RecycleMachine>();
            }
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
    public GameObject GetRecycleO(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        var result = results.Where(x => x.gameObject.CompareTag("Obstacle")).FirstOrDefault();
        return result.gameObject;
    }
    public GameObject GetRecycleT(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        var result = results.Where(x => x.gameObject.CompareTag("TimeMachine")).FirstOrDefault();
        return result.gameObject;
    }
    public void ItemGet(int ID)
    {
        if (MaterialManager.Instance.CheckMaterial(allItems[ID].UseMaterials))
        {
            MaterialManager.Instance.UseMaterial(allItems[ID].UseMaterials);
            inventory.AddItem(allItems[ID]);
            if (Player.Instance.create)
            {
                Player.Instance.create.ViweCreat();
            }
        }
    }

    public ItemBaseData GetItem(int ID)
    {
        return allItems[ID];
    }
}
