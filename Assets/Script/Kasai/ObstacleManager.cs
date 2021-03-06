using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>障害物を管理する </summary>
public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            Debug.Log(collision.name);
            Destroy(this.gameObject);
        }
    }
}
