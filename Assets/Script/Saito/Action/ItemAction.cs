using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    Rigidbody2D m_rb;
    [SerializeField] float m_maxSpeed = 2f;
    [SerializeField] float m_movePower = 10f;

    public enum Materal
    {
        Kan,
        Petbottle
    }
    [SerializeField] Materal type = Materal.Kan;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector2 playerVec = new Vector2(m_player.transform.position.x, m_player.transform.position.y);
            m_rb.velocity = playerVec - (new Vector2(this.transform.position.x, this.transform.position.y));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ItemManagerAction itemManager = FindObjectOfType<ItemManagerAction>();
            itemManager.GetItem(this.type);
            Destroy(this.gameObject);
        }
    }
}
