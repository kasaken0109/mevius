using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMessage : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    RectTransform rect;
    [SerializeField]
    GameObject[] messages;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position);
    }
    /// <summary>
    /// 指定したメッセージ表示、０：リサイクル、１：拾う、２：作成、３：調べる
    /// </summary>
    /// <param name="ID"></param>
    public void OpenMessage(int ID)
    {
        CloseAll();
        switch (ID)
        {
            case 0:
                messages[ID].SetActive(true);
                break;
            case 1:
                messages[ID].SetActive(true);
                break;
            case 2:
                messages[ID].SetActive(true);
                break;
            case 3:
                messages[ID].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void CloseAll()
    {
        messages.ToList().ForEach(i => i.SetActive(false));
    }
}
