using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : ItemBase
{
    public override ItemBase GetItem()
    {
        ItemManager.metalNumber++;
        this.gameObject.SetActive(false);
//        ItemManager.ChangeText();
        return this;
    }
}
