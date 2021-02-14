using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary> 敵の体力/// </summary>
    [SerializeField] int m_hp = 10;
    /// <summary> 敵の落とす素材/// </summary>
    [SerializeField] GameObject m_drop = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    /// 敵がダメージを受けたときに呼ばれる関数
    /// </summary>
    public void Damage(int power)
    {
        m_hp -= power;
        //Debug.Log($"敵にpowerのダメージを与えた！");
    }
}
