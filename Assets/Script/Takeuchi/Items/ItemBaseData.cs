using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Items", menuName = "Items/Item")]
public class ItemBaseData : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
}

