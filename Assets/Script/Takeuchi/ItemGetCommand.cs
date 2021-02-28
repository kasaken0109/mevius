using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CommandType
{
    GetGarbage,
    GetTool,
}
public class ItemGetCommand : MonoBehaviour
{
    [SerializeField]
    CommandType command = CommandType.GetGarbage;

    public void OnClickThis()
    {
        switch (command)
        {
            case CommandType.GetGarbage:
                IinventoryManager.Instance.ItemGet(0);
                break;
            case CommandType.GetTool:
                IinventoryManager.Instance.ItemGet(1);
                break;
            default:
                break;
        }
    }
}
