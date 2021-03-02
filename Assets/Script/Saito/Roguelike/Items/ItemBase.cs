using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    public int posX;
    public int posY;
    private float squaresSize;
    [SerializeField] GameObject m_woodText;
    [SerializeField] GameObject m_metalText;
    void Start()
    {
        Setup();
    }
    void Setup()
    {
        posX = Random.Range(0, MapBase.Instance.GetMapMaxX());
        posY = Random.Range(0, MapBase.Instance.GetMapMaxY());
        squaresSize = MapBase.Instance.GetSquaresSize();
        transform.position = new Vector2(posX * squaresSize, posY * squaresSize);
        MapBase.Instance.SetItemOnSquares(posX, posY, this);
    }
    
    public virtual ItemBase GetItem() { return this; }
    
}
