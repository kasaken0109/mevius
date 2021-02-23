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
                    Material material = instance.GetComponent<Material>();
                    material.StartMove(transform.position, GetDirection(30 * i));
                }
                break;
            case ToolsType.Shovel:
                for (int i = 0; i < 3; i++)
                {
                    GameObject instance = Instantiate<GameObject>(dropMaterialsPrefab[1]);
                    Material material = instance.GetComponent<Material>();
                    material.StartMove(transform.position , GetDirection(30 * i));
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
