using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary> 体力 </summary>
    [SerializeField] int m_hp = 10;
    /// <summary> 落とす素材 </summary>
    [SerializeField] GameObject m_drop = null;
    /// <summary> 落とす素材の数 </summary>
    [SerializeField] public int m_dropNum = 2;
    /// <summary> 動く速度 </summary>
    [SerializeField] int m_speed = 10;
    /// <summary> 攻撃力 </summary>
    [SerializeField] int m_power = 10;
    [SerializeField] Animation m_animation;
    /// <summary>攻撃出来るかどうかのフラグ</summary>
    public bool attackFlag = false;
    /// <summary> 動けるかどうか判定するフラグ </summary>
    public bool MoveMode = false;

    TurnManager turnManager;
    ItemManager itemManager;
    MapBase mapBase;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (turnManager.turnName == TurnManager.TurnName.PLAYERMOVE)
        //{
        //    turnManager.turnName = TurnManager.TurnName.ENEMYMOVE;
        //    Move();
        //}
        //else if (turnManager.turnName == TurnManager.TurnName.ENEMYATTACK)
        //{
        //    Hit();
        //}
        if ()
        {

        }


        switch (turnManager.turnName)
        {
            case TurnManager.TurnName.PLAYERMOVE:
                turnManager.turnName = TurnManager.TurnName.ENEMYMOVE;
                break;
            case TurnManager.TurnName.ENEMYMOVE:
                Move();
                break;
            case TurnManager.TurnName.PLAYERATTACK:
                turnManager.turnName = TurnManager.TurnName.ENEMYATTACK;
                break;
            case TurnManager.TurnName.ENEMYATTACK:
                Hit();
                break;
            default:
                break;
        }
        if (m_hp <= 0)
        {
            Instantiate(m_drop, this.transform.position, this.transform.rotation);
            Debug.Log("敵が" + m_drop + "を落とした！");
            itemManager.AddItem(m_dropNum);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    /// <summary>
    /// 攻撃をする関数
    /// </summary>
    public void Hit()
    {
        if (attackFlag)
        {
            Player.Hit(m_power);
        }
    }

    /// <summary>
    /// 攻撃を受けたときに呼ばれる関数
    /// </summary>
    /// <param name="power">プレイヤーの攻撃力</param>
    public void Damage(int power)
    {
        m_hp -= power;
        Debug.Log("敵に" + power + "のダメージを与えた！");
    }

    /// <summary>
    /// 動く関数(今はいらないが今後使うように作成した)
    /// </summary>
    public void Move()
    {
        if (MoveMode)
        {

        }
    }
}
