using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private float moveX;
    private float moveY;
    /// <summary> 主人公の装備状態 </summary>
    [SerializeField] EquipType equipTools = EquipType.None;
    public static Player Instance { get; private set; }
    Garbage garbage;
    public TimeMachine timeMachine;
    public Obstacle obstacle;
    public CreateMachine create;
    private Rigidbody2D rB = null;
    private Tools[] useTools;
    private Tools haveTool;
    [SerializeField]
    GameObject message;
    [SerializeField]
    GameObject[] plyerUI;
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
        message.SetActive(false);
        OnClickCancel();
    }
    private void Update()
    {
        if (moveNow)
        {
            CurrentPosX = transform.position.x;
            CurrentPosY = transform.position.y;
            if (CurrentPosX > maxPosX)
            {
                moveX = 0;
            }
            if (CurrentPosX < -maxPosX)
            {
                moveX = 0;
            }
            if (CurrentPosY > maxPosY)
            {
                moveY = 0;
            }
            if (CurrentPosY < -maxPosY)
            {
                moveY = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        //入力があれば移動、
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveNow = true;
            CurrentPosX = transform.position.x;
            CurrentPosY = transform.position.y;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveX = moveSpeed;
                angle = MoveAngle.Right;
                if (CurrentPosX > maxPosX)
                {
                    moveX = 0;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveX = -moveSpeed;
                angle = MoveAngle.Left;
                if (CurrentPosX < -maxPosX)
                {
                    moveX = 0;
                }
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                moveY = moveSpeed;
                angle = MoveAngle.Up;
                if (CurrentPosY > maxPosY)
                {
                    moveY = 0;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                moveY = -moveSpeed;
                angle = MoveAngle.Down;
                if (CurrentPosY < -maxPosY)
                {
                    moveY = 0;
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
            moveNow = false;
        }
        else
        {
            moveX = 0;
            moveY = 0;
        }
        rB.velocity = new Vector2(moveX, moveY);
        CurrentPosX = transform.position.x;
        CurrentPosY = transform.position.y;
        if (CurrentPosX > maxPosX)
        {
            moveX = 0;
        }
        if (CurrentPosX < -maxPosX)
        {
            moveX = 0;
        }
        if (CurrentPosY > maxPosY)
        {
            moveY = 0;
        }
        if (CurrentPosY < -maxPosY)
        {
            moveY = 0;
        }
    }

    public void SetTools(Tools tool)
    {
        switch (tool.toolType)
        {
            case ToolsType.Hammer:
                useTools[0] = tool;
                Debug.Log("ピッケルを作った");
                break;
            case ToolsType.Shovel:
                useTools[1] = tool;
                Debug.Log("シャベルを作った");
                break;
            case ToolsType.ChainSaw:
                useTools[2] = tool;
                Debug.Log("チェーンソーを作った");
                break;
            default:
                break;
        }
        haveTool = tool;
    }
    public void OnClickChangeTools()
    {
        if (haveTool)
        {
            switch (haveTool.toolType)
            {
                case ToolsType.Hammer:
                    if (useTools[1])
                    {
                        haveTool = useTools[1];
                        Debug.Log("シャベルに持ち替えた");
                    }
                    break;
                case ToolsType.Shovel:
                    if (useTools[0])
                    {
                        haveTool = useTools[0];
                        Debug.Log("ピッケルに持ち替えた");
                    }
                    break;
                case ToolsType.ChainSaw:
                    break;
                default:
                    break;
            }
        }
        else
        {
            foreach (var item in useTools)
            {
                if (item)
                {
                    haveTool = item;
                    return;
                }
            }
        }
    }
    public void OnClickRecycle()
    {
        plyerUI[0].SetActive(true);
    }
    public void OnClickPickUp()
    {
        plyerUI[1].SetActive(true);
    }
    public void OnClickTimeMachine()
    {
        plyerUI[3].SetActive(true);
    }
    public void OnClickCancel()
    {
        plyerUI.ToList().ForEach(i => i.SetActive(false));
    }
    public void OnClickCraft()
    {
        plyerUI[2].SetActive(true);
        if (create)
        {
            create.ViweCreat();
        }
    }
    public void OnClickObstacle()
    {
        if (obstacle)
        {
            obstacle.Open();
        }
    }
    public void OnClickToTakeApartTool()
    {
        if (haveTool)
        {
            switch (haveTool.toolType)
            {
                case ToolsType.Hammer:
                    useTools[0] = null;
                    haveTool.ToTakeApartTool();
                    break;
                case ToolsType.Shovel:
                    useTools[1] = null;
                    haveTool.ToTakeApartTool();
                    break;
                case ToolsType.ChainSaw:
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Garbage garbage = collision.GetComponent<Garbage>();
        if (garbage)
        {
            this.garbage = garbage;
            message.SetActive(true);
            message.GetComponent<PlayerMessage>().OpenMessage(1);
        }
        else
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if (obstacle)
            {
                this.obstacle = obstacle;
                message.SetActive(true);
                message.GetComponent<PlayerMessage>().OpenMessage(3);
            }
            else
            {
                RecycleMachine recycle = collision.GetComponent<RecycleMachine>();
                if (recycle)
                {
                    message.SetActive(true);
                    message.GetComponent<PlayerMessage>().OpenMessage(0);
                }
                else
                {
                    CreateMachine create = collision.GetComponent<CreateMachine>();
                    if (create)
                    {
                        this.create = create;
                        message.SetActive(true);
                        message.GetComponent<PlayerMessage>().OpenMessage(2);                        
                    }
                    else
                    {
                        TimeMachine timeMachine = collision.GetComponent<TimeMachine>();
                        if (timeMachine)
                        {
                            this.timeMachine = timeMachine;
                            message.SetActive(true);
                            message.GetComponent<PlayerMessage>().OpenMessage(4);
                        }
                    }
                }
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
            message.SetActive(false);
        }
        else
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if (obstacle)
            {
                this.obstacle = null;
                message.SetActive(false);
            }
            else
            {
                RecycleMachine recycle = collision.GetComponent<RecycleMachine>();
                if (recycle)
                {
                    message.SetActive(false);
                }
                else
                {
                    CreateMachine create = collision.GetComponent<CreateMachine>();
                    if (create)
                    {
                        this.create = null;
                        message.SetActive(false);
                    }
                    else
                    {
                        TimeMachine timeMachine = collision.GetComponent<TimeMachine>();
                        if (timeMachine)
                        {
                            this.timeMachine = null;
                            message.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
