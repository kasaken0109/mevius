using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int power;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAction.Instance.Damage(power,this.transform.position);
        }
    }
    public void SetPower(int power)
    {
        this.power = power;
    }
}
