using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField]
    private int totalDoropNumber = 5;
    [SerializeField]
    private int garbageType = 0;
    public void DropMaterial(ToolsType tool)
    {
        switch (tool)
        {
            case ToolsType.Hammer:
                if (garbageType == 0 && totalDoropNumber > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[2]);
                        Material material = instance.GetComponent<Material>();
                        material.StartMove(transform.position, GetDirection(30 * i));
                    }
                    totalDoropNumber--;
                }
                else
                {
                    Debug.Log("上手く取れない");
                }
                break;
            case ToolsType.Shovel:
                if (garbageType == 1 && totalDoropNumber > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[3]);
                        Material material = instance.GetComponent<Material>();
                        material.StartMove(transform.position, GetDirection(30 * i));
                    }
                    totalDoropNumber--;
                }
                else
                {
                    Debug.Log("上手く取れない");
                }
                break;
            default:
                break;
        }
    }
    Vector3 GetDirection(float angle)
    {
        return new Vector3
        (
            Mathf.Sin(angle * Mathf.Deg2Rad),
            Mathf.Cos(angle * Mathf.Deg2Rad),
            0.0f
        ).normalized;
    }
}
