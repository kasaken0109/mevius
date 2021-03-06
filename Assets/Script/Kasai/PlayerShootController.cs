using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 打ち出した弾に関する処理
/// </summary>
public class PlayerShootController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    /// <summary>弾の速度</summary>
    [SerializeField] float m_bulletSpeed = 1f;
    /// <summary>弾の攻撃力</summary>
    [SerializeField] int m_bulletPower = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(1, 0) * m_bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAction>().Damage(m_bulletPower);
        }
    }
}
