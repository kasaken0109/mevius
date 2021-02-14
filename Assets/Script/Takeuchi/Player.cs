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
    private float positionUpdate;
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
        if (Input.GetAxisRaw("Horizontal") != 0 && positionUpdate == 0 || Input.GetAxisRaw("Vertical") != 0 && positionUpdate == 0)
        {            
            if (Input.GetAxisRaw("Horizontal") > 0 )
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX+1, CurrentPosY))
                {
                    CurrentPosX++;
                    ud = true;
                    lr = true;
                    positionUpdate = 1.0f;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 )
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX-1, CurrentPosY))
                {
                    CurrentPosX--;
                    ud = false;
                    lr = false;
                    positionUpdate = 1.0f;
                }
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX, CurrentPosY + 1))
                {
                    CurrentPosY++;
                    ud = true;
                    lr = false;
                    positionUpdate = 1.0f;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX, CurrentPosY - 1))
                {
                    CurrentPosY--;
                    ud = false;
                    lr = true;
                    positionUpdate = 1.0f;
                }
            }
        }        
        if (positionUpdate > 0)
        {
            positionUpdate -= moveSpeed * Time.deltaTime;
            if (positionUpdate <= 0)
            {
                positionUpdate = 0;
                //ここでターン終了処理呼び出し
            }
            if (ud && !lr)
            {
                transform.position = new Vector2(CurrentPosX * squaresSize, (CurrentPosY - positionUpdate) * squaresSize);
            }
            else if (!ud && lr)
            {
                transform.position = new Vector2(CurrentPosX * squaresSize, (CurrentPosY + positionUpdate) * squaresSize);
            }
            else if (ud && lr)
            {
                transform.position = new Vector2((CurrentPosX - positionUpdate) * squaresSize, CurrentPosY * squaresSize);
            }
            else if (!ud && !lr)
            {
                transform.position = new Vector2((CurrentPosX + positionUpdate) * squaresSize, CurrentPosY * squaresSize);
            }
        }
    }
}
