using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public int posX;
    public int posY;
    private float squaresSize;
    private void Start()
    {
        squaresSize = MapBase.Instance.GetSquaresSize();
        transform.position = new Vector2(posX * squaresSize, posY * squaresSize);
    }
    
    /// <summary> 素材の種類 </summary>
    public enum RecycleMaterial
    {
        Wood,
        Metal
    }
}
