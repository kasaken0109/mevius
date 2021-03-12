using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    public List<ItemData> craftData = new List<ItemData>();
    private void Start()
    {
        
    }
    public void ItemCrafting()
    {
        
        if (ItemManage.Instance.itemList[craftData[0]] != 0)
        {
            Debug.Log("a");
        }
        else
        {
            Debug.Log("b");
        }
    }
}
