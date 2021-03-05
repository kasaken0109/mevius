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

    public void Damage(int damege)
    {
        CurrentHP -= damege;
        if (CurrentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            Damage(PlayerAction.Instance.GetPlayerPower());
        }
    }
}
