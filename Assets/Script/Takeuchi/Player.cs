using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状態分け
/// </summary>
public enum StateType
{
    Wait,
    Move,
    Attack,
    Damage,
}
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
    /// <summary> 移動速度 </summary>
    [SerializeField] private float moveSpeed = 1.0f;
    private float squaresSize;
    private float positionUpdate;
    private float inputTimer;
    private enum MoveAngle
    {
        Up,
        Down,
        Left,
        Right,
    }
    /// <summary> 移動方向 </summary>
    [SerializeField] private MoveAngle angle = MoveAngle.Down;
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
        //入力があれば移動、
        if (Input.GetAxisRaw("Horizontal") != 0 && positionUpdate == 0 && inputTimer <= 0 || Input.GetAxisRaw("Vertical") != 0 && positionUpdate == 0 && inputTimer <= 0)
        {            
            if (Input.GetAxisRaw("Horizontal") > 0 )
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX+1, CurrentPosY))
                {
                    CurrentPosX++;
                    angle = MoveAngle.Right;
                    positionUpdate = 1.0f;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 )
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX-1, CurrentPosY))
                {
                    CurrentPosX--;
                    angle = MoveAngle.Left;
                    positionUpdate = 1.0f;
                }
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX, CurrentPosY + 1))
                {
                    CurrentPosY++;
                    angle = MoveAngle.Up;
                    positionUpdate = 1.0f;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (!MapBase.Instance.GetSquaresNoIntrusion(CurrentPosX, CurrentPosY - 1))
                {
                    CurrentPosY--;
                    angle = MoveAngle.Down;
                    positionUpdate = 1.0f;
                }
            }
            //ここでアイテムがあればターン終了時に取得
            MapBase.Instance.GetItemOnSquares(CurrentPosX, CurrentPosY);
            inputTimer = 0.5f;
        }        
        //移動した際の処理
        if (positionUpdate > 0)
        {
            positionUpdate -= moveSpeed * Time.deltaTime;
            if (positionUpdate <= 0)
            {
                positionUpdate = 0;
                //ここでターン終了処理呼び出し
            }
            switch (angle)//移動演出
            {
                case MoveAngle.Up:
                    transform.position = new Vector2(CurrentPosX * squaresSize, (CurrentPosY - positionUpdate) * squaresSize);
                    break;
                case MoveAngle.Down:
                    transform.position = new Vector2(CurrentPosX * squaresSize, (CurrentPosY + positionUpdate) * squaresSize);
                    break;
                case MoveAngle.Left:
                    transform.position = new Vector2((CurrentPosX + positionUpdate) * squaresSize, CurrentPosY * squaresSize);
                    break;
                case MoveAngle.Right:
                    transform.position = new Vector2((CurrentPosX - positionUpdate) * squaresSize, CurrentPosY * squaresSize);
                    break;
                default:
                    break;
            }
        }
        if (inputTimer > 0)
        {
            inputTimer -= Time.deltaTime;
        }
    }

}
