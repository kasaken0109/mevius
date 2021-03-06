using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ステージの管理をする
/// </summary>
public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    ///<summary>スポーンする地点</summary>
    Transform m_spawn = null;
    void Start()
    {
        m_spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = m_spawn.position;
            collision.gameObject.SetActive(true);
        }
    }
}
