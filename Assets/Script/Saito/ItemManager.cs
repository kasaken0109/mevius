using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /// <summary> 木材の所持数 </summary>
    public static int woodNumber = 0;
    /// <summary> 鉄の所持数 </summary>
    public static int metalNumber = 0;
    [SerializeField] GameObject rodPrefab;
    [SerializeField] GameObject sawPrefab;
    
    public void CraftRod()
    {
        if (woodNumber >= CraftData.RodWoodValue && metalNumber >= CraftData.RodMetalValue)
        {
            Instantiate(rodPrefab, this.gameObject.transform);
            woodNumber -= CraftData.RodWoodValue;
            metalNumber -= CraftData.RodMetalValue;
        }
    }
    public void CraftSaw()
    {
        if (woodNumber >= CraftData.SawWoodValue && metalNumber >= CraftData.SawMetalValue)
        {
            Instantiate(sawPrefab, this.gameObject.transform);
            woodNumber -= CraftData.SawWoodValue;
            metalNumber -= CraftData.SawMetalValue;
        }
    }
    
}
