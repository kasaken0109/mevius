using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    Rigidbody2D m_rb;
    [SerializeField]
    bool directionLR;
    bool directionChange;
    [SerializeField]
    int playerMaxHP = 15;
    public int CurrentHP { get; private set; }
    [SerializeField]
    int power = 5;
    [SerializeField]
    GameObject attack;
    float attackTimer;
    int attackPower = 5;
    [SerializeField]
    SearchPlayer player;
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    SearchPlayer attackPos;
    [SerializeField]
    EnemyAttack enemyAttack;
    float damegeTimer;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();        
        CurrentHP = playerMaxHP;
        attack.SetActive(false);
        directionChange = true;
        enemyAttack.SetPower(attackPower);
    }
    private void Update()
    {
        if (damegeTimer > 0)
        {
            damegeTimer -= Time.deltaTime;
        }
        else
        {
            if (player.OnPlayer)
            {
                FindPlayerMove();
                AttackPlayer();
            }
            if (directionChange)
            {
                if (directionLR)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                directionChange = false;
            }
        }
    }
    public void Damage(int damege)
    {
        if (damegeTimer <= 0)
        {
            CurrentHP -= damege;
            if (CurrentHP <= 0)
            {
                Dead();
            }
            damegeTimer = 1f;
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            Damage(PlayerAction.Instance.GetPlayerPower());
            if (PlayerAction.Instance.directionLR)
            {
                m_rb.AddForce(Vector2.right * 30f, ForceMode2D.Impulse);
            }
            else
            {
                m_rb.AddForce(Vector2.right * -30f, ForceMode2D.Impulse);
            }
            Debug.Log(CurrentHP);
        }
    }

    private void FindPlayerMove()
    {
        Vector2 dir = Vector2.zero;
        float target = PlayerAction.Instance.transform.position.x - transform.position.x;
        if (target > 0)
        {
            dir = Vector2.right * moveSpeed;
            if (!directionLR)
            {
                directionLR = true;
                directionChange = true;
            }
        }
        else if(target < 0)
        {
            dir = Vector2.right * -moveSpeed;
            if (directionLR)
            {
                directionLR = false;
                directionChange = true;
            }
        }
        dir.y = m_rb.velocity.y;
        m_rb.velocity = dir;
    }

    private void AttackPlayer()
    {
        if (attackPos.OnPlayer && attackTimer <= 0)
        {
            attack.SetActive(true);
            attackTimer = 2f;
        }
        else if (attackTimer <= 1.8f && attackTimer > 0)
        {
            attack.SetActive(false);
            m_rb.velocity = Vector2.zero;
        }
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        
    }
}
