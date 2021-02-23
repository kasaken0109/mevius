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
    ChainSaw,
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
    Garbage garbage;
    Obstacle obstacle;
    private Rigidbody2D rB = null;
    private Tools[] useTools;
    private Tools haveTool;
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
        useTools = new Tools[3];
    }
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(CurrentPosX, CurrentPosY);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (garbage)
            {
                if (haveTool)
                {
                    garbage.DropMaterial(equipTools);
                }
            }
            else if (obstacle)
            {
                if (haveTool)
                {
                    obstacle.BreakObstacle();
                }
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
        switch (tool.toolType)
        {
            case ToolsType.Hammer:
                useTools[0] = tool;
                break;
            case ToolsType.Shovel:
                useTools[1] = tool;
                break;
            case ToolsType.ChainSaw:
                useTools[2] = tool;
                break;
            default:
                break;
        }
        haveTool = tool;
    }
    public void OnClickChangeTools()
    {
        if(equipTools == EquipType.Hammer)
        {
            equipTools = EquipType.Shovel;
            haveTool = useTools[1];
        }
        else if (equipTools == EquipType.Shovel)
        {
            equipTools = EquipType.Hammer;
            haveTool = useTools[0];
        }
    }
    public void OnClickCraftHammer()
    {
        ToolsManager.Instance.CreateTools(0);
        equipTools = EquipType.Hammer;
    }
    public void OnClickCraftShovel()
    {
        ToolsManager.Instance.CreateTools(1);
        equipTools = EquipType.Shovel;
    }
    public void OnClickCraftChainSaw()
    {
        ToolsManager.Instance.CreateTools(2);
        equipTools = EquipType.ChainSaw;
    }
    public void OnClickToTakeApartTool()
    {
        if (equipTools == EquipType.Hammer)
        {
            useTools[0] = null;
            if (haveTool)
            {
                haveTool.ToTakeApartTool();
                equipTools = EquipType.None;
            }
        }
        else if (equipTools == EquipType.Shovel)
        {
            useTools[1] = null;
            if (haveTool)
            {
                haveTool.ToTakeApartTool();
                equipTools = EquipType.None;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Garbage garbage = collision.GetComponent<Garbage>();
        if (garbage)
        {
            this.garbage = garbage;
        }
        else
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if (obstacle)
            {
                this.obstacle = obstacle;
            }
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
        else
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if (obstacle)
            {
                this.obstacle = null;
            }
        }
    }
}
