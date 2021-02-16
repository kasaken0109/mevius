using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    /// <summary> 木材の所持数 </summary>
    public int woodNumber = 0;
    /// <summary> 鉄の所持数 </summary>
    public int metalNumber = 0;
    private GameObject[] items;

    /// <summary>
    /// プレイヤーと重なってるアイテムを取得する
    /// </summary>
    public void SetItem()
    {
        GameObject player = GameObject.Find("Player");
        items = GameObject.FindGameObjectsWithTag("Item");
        foreach (var item in items)
        {
            if (item.transform.position.x == player.transform.position.x && item.transform.position.y == player.transform.position.y)
            {
                if (item.GetComponent<Wood>())
                {
                    woodNumber++;
                    Destroy(item);
                }
                if (item.GetComponent<Metal>())
                {
                    metalNumber++;
                    Destroy(item);
                }
            }
        }   
    } 
}
