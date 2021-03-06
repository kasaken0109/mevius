using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ItemAction : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    Rigidbody2D m_rb;
    [SerializeField] ItemManagerAction itemManager;
    public bool m_moveChack = false;
    Vector2 dir;
    private bool m_hitCheck = false;
    public enum Materal
    {
        Combustible,
        Plastic,
        Oversize
    }
    [SerializeField] Materal type = Materal.Combustible;

    private void Start()
    {

        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (m_moveChack)
        {
            Vector2 playerVec = new Vector2(PlayerAction.Instance.transform.position.x, PlayerAction.Instance.transform.position.y);
            dir = playerVec - (new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y));
            m_rb.velocity = dir;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !m_hitCheck)
        {
            m_hitCheck = true;
            if (this.type == Materal.Combustible && ItemManagerAction.Instance.m_combustibleNum < ItemManagerAction.Instance.m_combustibleMaxNum)
            {
                ItemManagerAction.Instance.SetCombustible(20);
            }
            else if (this.type == Materal.Plastic && ItemManagerAction.Instance.m_plasticNum < ItemManagerAction.Instance.m_plasticMaxNum)
            {
                ItemManagerAction.Instance.SetPlastic(20);
            }
            else if (this.type == Materal.Oversize && ItemManagerAction.Instance.m_oversizeNum < ItemManagerAction.Instance.m_oversizeMaxNum)
            {
                ItemManagerAction.Instance.SetOversize(20);
            }
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collection")
        {
            m_moveChack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collection")
        {
            m_moveChack = false;
        }
    }

}
