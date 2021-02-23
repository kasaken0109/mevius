using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 装備状態分け
/// </summary>
public enum EquipType
{
    None,
    Hammer,
    Shovel,
}
public class Player : MonoBehaviour
{
    /// <summary>プレイヤーX座標初期位置</summary>
    [SerializeField] private float startPosX;
    /// <summary>プレイヤーY座標初期位置</summary>
    [SerializeField] private float startPosZ;
    /// <summary>プレイヤーX座標現在地</summary>
    public float CurrentPosX { get; protected set; }
    /// <summary>プレイヤーY座標現在地</summary>
    public float CurrentPosY { get; protected set; }
    /// <summary> 移動速度 </summary>
    [SerializeField] private float moveSpeed = 1.0f;
    private bool moveNow;
    [SerializeField]
    private float maxPosX;
    [SerializeField]
    private float maxPosY;
    /// <summary> 主人公の装備状態 </summary>
    [SerializeField] EquipType equipTools = EquipType.None;
    public static Player Instance { get; private set; }
    [SerializeField]
    Garbage garbage;
    private Rigidbody2D rB = null;
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
        Instance = this;
    }
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(CurrentPosX, CurrentPosY);
    }

    void Update()
    {
        //入力があれば移動、
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveNow = true;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                CurrentPosX += moveSpeed * Time.deltaTime;
                angle = MoveAngle.Right;
                if (CurrentPosX > maxPosX)
                {
                    CurrentPosX = maxPosX;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                CurrentPosX -= moveSpeed * Time.deltaTime;
                angle = MoveAngle.Left;
                if (CurrentPosX < -maxPosX)
                {
                    CurrentPosX = -maxPosX;
                }
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                CurrentPosY += moveSpeed * Time.deltaTime;
                angle = MoveAngle.Up;
                if (CurrentPosY > maxPosY)
                {
                    CurrentPosY = maxPosY;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                CurrentPosY -= moveSpeed * Time.deltaTime;
                angle = MoveAngle.Down;
                if (CurrentPosY < -maxPosY)
                {
                    CurrentPosY = -maxPosY;
                }
            }
        }
        //移動した際の処理
        if (moveNow)
        {
            switch (angle)//移動演出、アニメーションはここで分岐
            {
                case MoveAngle.Up:
                    break;
                case MoveAngle.Down:
                    break;
                case MoveAngle.Left:
                    break;
                case MoveAngle.Right:
                    break;
                default:
                    break;
            }
            //transform.position = new Vector2(CurrentPosX, CurrentPosY);
            //rB.velocity = new Vector2(CurrentPosX, CurrentPosY);
            moveNow = false;
        }
        else
        {
            //rB.velocity = new Vector2(0, 0);
            CurrentPosX = 0;
            CurrentPosY = 0;
        }
        rB.velocity = new Vector2(CurrentPosX, CurrentPosY);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            garbage.DropMaterial(equipTools);
        }
    }

}
