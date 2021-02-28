using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMessage : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position);
    }
}
