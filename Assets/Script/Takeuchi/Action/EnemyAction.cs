using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    Rigidbody2D m_rb;
    [SerializeField]
    bool directionLR;
    [SerializeField]
    int playerMaxHP = 15;
    public int CurrentHP { get; private set; }
    [SerializeField]
    int power = 5;
    [SerializeField]
    GameObject attack;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();        
        CurrentHP = playerMaxHP;
        attack.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void Damage(int damege)
    {
        CurrentHP -= damege;
        if (CurrentHP <= 0)
        {
            Dead();
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

}
