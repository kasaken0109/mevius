using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : ItemBase
{
    public override ItemBase GetItem() 
    {
        ItemManager.woodNumber++;
        this.gameObject.SetActive(false);
        return this;
    }
}
