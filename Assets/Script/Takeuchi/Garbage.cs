using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField]
    GameObject[] dropMaterialsPrefab;
    [SerializeField]
    private int totalDoropNumber = 5;
    public void DropMaterial(ToolsType tool)
    {
        switch (tool)
        {
            case ToolsType.None:
                break;
            case ToolsType.Hammer:
                for (int i = 0; i < 3; i++)
                {
                    GameObject instance = Instantiate<GameObject>(dropMaterialsPrefab[0]);
                }
                break;
            case ToolsType.Shovel:
                for (int i = 0; i < 3; i++)
                {
                    GameObject instance = Instantiate<GameObject>(dropMaterialsPrefab[1]);
                }
                break;
            default:
                break;
        }
    }
}
