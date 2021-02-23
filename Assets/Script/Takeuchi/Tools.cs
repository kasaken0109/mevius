using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolsType
{
    Hammer,
    Shovel,
    ChainSaw,
}
public class Tools : MonoBehaviour
{
    [SerializeField]
    public ToolsType toolType = ToolsType.Hammer;
    [SerializeField]
    public int[] recipe;
    private void Start()
    {
        transform.position = Player.Instance.transform.position;
        Player.Instance.SetTools(this);
    }
    public void ToTakeApartTool()
    {
        GameObject instance;
        Material material;
        switch (toolType)
        {
            case ToolsType.Hammer:
                instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[0]);
                material = instance.GetComponent<Material>();
                material.StartMove(transform.position, GetDirection(30));
                instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[1]);
                material = instance.GetComponent<Material>();
                material.StartMove(transform.position, GetDirection(-30));
                break;
            case ToolsType.Shovel:
                instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[0]);
                material = instance.GetComponent<Material>();
                material.StartMove(transform.position, GetDirection(30));
                instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[1]);
                material = instance.GetComponent<Material>();
                material.StartMove(transform.position, GetDirection(-30));
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
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
