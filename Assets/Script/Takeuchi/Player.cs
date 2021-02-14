using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>プレイヤーX座標初期位置</summary>
    [SerializeField] private int startPosX;
    /// <summary>プレイヤーY座標初期位置</summary>
    [SerializeField] private int startPosZ;
    /// <summary>プレイヤーX座標現在地</summary>
    public int CurrentPosX { get; protected set; }
    /// <summary>プレイヤーY座標現在地</summary>
    public int CurrentPosY { get; protected set; }
    private float squaresSize;
    private float positionUpdateTimer;
    private void Awake()
    {
        CurrentPosX = startPosX;
        CurrentPosY = startPosZ;
    }
    void Start()
    {
        squaresSize = MapBase.Instance.GetSquaresSize();
        transform.position = new Vector2(CurrentPosX * squaresSize, CurrentPosY * squaresSize);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && positionUpdateTimer <= 0 || Input.GetAxisRaw("Vertical") != 0 && positionUpdateTimer <= 0)
        {
            positionUpdateTimer = 0.5f;
            if (Input.GetAxisRaw("Horizontal") > 0 )
            {
                CurrentPosX++;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 )
            {
                CurrentPosX--;
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                CurrentPosY++;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                CurrentPosY--;
            }
            transform.position = new Vector2(CurrentPosX * squaresSize, CurrentPosY * squaresSize);
        }
        
        if (positionUpdateTimer > 0)
        {
            positionUpdateTimer -= Time.deltaTime;            
        }
    }
}
