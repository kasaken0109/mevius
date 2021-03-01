using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    [SerializeField]
    GameObject message;
    private void Start()
    {
        message.SetActive(false);
    }
    public void Message()
    {
        message.SetActive(true);
        Debug.Log("クリア");
    }
}
