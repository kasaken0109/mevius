using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary> 敵の体力 </summary>
    [SerializeField] int m_hp = 10;
    /// <summary> 敵の落とす素材 </summary>
    [SerializeField] GameObject m_drop = null;
    /// <summary> 敵の動く速度 </summary>
    [SerializeField] int m_speed = 10;
    /// <summary>  </summary>
    public bool attackFlag = false;
    TurnManager turnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turnManager.turnName == TurnManager.TurnName.MOVE)
        {

        }
        else if (turnManager.turnName == TurnManager.TurnName.ATTACK)
        {
            Hit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    /// <summary>
    /// 敵が攻撃をする関数
    /// </summary>
    public void Hit()
    {

    }

    /// <summary>
    /// 敵が攻撃を受けたときに呼ばれる関数
    /// </summary>
    /// <param name="power">プレイヤーの攻撃力</param>
    public void Damage(int power)
    {
        m_hp -= power;
        Debug.Log("敵に" + power + "のダメージを与えた！");
        if (m_hp == 0)
        {
            Instantiate(m_drop, this.transform.position, this.transform.rotation);
            Debug.Log("敵に" + power + "のダメージを与えた！");
        }
    }

    public void Move()
    {

    }
}
