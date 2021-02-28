using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMachine : MonoBehaviour
{
    [SerializeField]
    GameObject[] creatTools;
    [SerializeField]
    ItemBaseData[] items;

    public void ViweCreat()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (MaterialManager.Instance.CheckMaterial(items[i].UseMaterials))
            {
                creatTools[i].SetActive(true);
            }
            else
            {
                creatTools[i].SetActive(false);
            }
        }
    }
}
