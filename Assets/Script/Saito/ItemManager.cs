using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /// <summary> 木材の所持数 </summary>
    public static int woodNumber = 0;
    /// <summary> 鉄の所持数 </summary>
    public static int metalNumber = 0;

    List<WeaponBase> weaponList = new List<WeaponBase>();
    private void Update()
    {
        if (woodNumber > 2)
        {
            
        }
    }
}
