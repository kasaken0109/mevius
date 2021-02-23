﻿using System.Collections;
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
    private List<Tools> useTools;
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
        useTools = new List<Tools>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (garbage)
            {
                garbage.DropMaterial(equipTools);
            }
            else
            {
                Debug.Log("該当なし");
            }
        }
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
    }

    public void SetTools(Tools tool)
    {
        useTools.Add(tool);
    }
    public void OnClickChangeTools()
    {
        if(equipTools == EquipType.Hammer)
        {
            equipTools = EquipType.Shovel;
        }
        else if (equipTools == EquipType.Shovel)
        {
            equipTools = EquipType.Hammer;
        }
    }
    public void OnClickCraftHammer()
    {

    }
    public void OnClickCraftShovel()
    {

    }
    public void OnClickToTakeApartTool()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Garbage garbage = collision.GetComponent<Garbage>();
        if (garbage)
        {
            this.garbage = garbage;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Garbage garbage = collision.GetComponent<Garbage>();
        if (garbage)
        {
            if (garbage == this.garbage)
            {
                this.garbage = null;
            }
        }
    }
}
