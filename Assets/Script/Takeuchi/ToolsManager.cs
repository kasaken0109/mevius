using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager Instance { get; private set; }
    [SerializeField]
    Tools[] AllTools;
    private void Awake()
    {
        Instance = this;
    }
    public void CreateTools(int orderTool)
    {
        if (MaterialManager.Instance.CheckMaterial(AllTools[orderTool].recipe))
        {
            MaterialManager.Instance.UseMaterial(AllTools[orderTool].recipe);
            Instantiate<Tools>(AllTools[orderTool]).transform.SetParent(Player.Instance.transform);
        }
        else
        {
            Debug.Log("素材が足りません");
        }
    }
}
