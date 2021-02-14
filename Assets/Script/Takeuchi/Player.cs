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
    [SerializeField]
    private float moveSpeed = 1.0f;
    private bool ud;
    private bool lr;
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
            positionUpdateTimer = 1.0f;
            if (Input.GetAxisRaw("Horizontal") > 0 )
            {
                CurrentPosX++;
                ud = true;
                lr = true;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 )
            {
                CurrentPosX--;
                ud = false;
                lr = false;
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                CurrentPosY++;
                ud = true;
                lr = false;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                CurrentPosY--;
                ud = false;
                lr = true;
            }
            //transform.position = new Vector2(CurrentPosX * squaresSize, CurrentPosY * squaresSize);
        }        
        if (positionUpdateTimer > 0)
        {
            positionUpdateTimer -= moveSpeed * Time.deltaTime;
            if (positionUpdateTimer < 0)
            {
                positionUpdateTimer = 0;
            }
            if (ud && !lr)
            {
                transform.position = new Vector2(CurrentPosX * squaresSize, (CurrentPosY - positionUpdateTimer) * squaresSize);
            }
            else if (!ud && lr)
            {
                transform.position = new Vector2(CurrentPosX * squaresSize, (CurrentPosY + positionUpdateTimer) * squaresSize);
            }
            else if (ud && lr)
            {
                transform.position = new Vector2((CurrentPosX - positionUpdateTimer) * squaresSize, CurrentPosY * squaresSize);
            }
            else if (!ud && !lr)
            {
                transform.position = new Vector2((CurrentPosX + positionUpdateTimer) * squaresSize, CurrentPosY * squaresSize);
            }
        }
    }
}
