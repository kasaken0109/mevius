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
    public enum Materal
    {
        Kan,
        Plastic,
        Oversize
    }
    [SerializeField] Materal type = Materal.Kan;

    private void Start()
    {

        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Fire2") && m_moveChack)
        {
            Vector2 playerVec = new Vector2(m_player.transform.position.x, m_player.transform.position.y);
            dir = playerVec - (new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y));
            m_rb.velocity = dir;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.type == Materal.Kan && ItemManagerAction.Instance.m_combustibleNum < ItemManagerAction.Instance.m_combustibleMaxNum)
            {
                ItemManagerAction.Instance.m_combustibleNum += 20;
            }
            else if (this.type == Materal.Plastic && ItemManagerAction.Instance.m_plasticNum < ItemManagerAction.Instance.m_plasticMaxNum)
            {
                ItemManagerAction.Instance.m_plasticNum += 20;
            }
            else if (this.type == Materal.Oversize && ItemManagerAction.Instance.m_oversizeNum < ItemManagerAction.Instance.m_plasticMaxNum)
            {
                ItemManagerAction.Instance.m_plasticNum += 20;
            }
            GetItem();
            Destroy(this.gameObject);
        }
    }
    public void GetItem()
    {
        DOTween.To(() => ItemManagerAction.Instance.m_combustibleGauge.value,
                    num => ItemManagerAction.Instance.m_combustibleGauge.value = num,
                    ItemManagerAction.Instance.m_combustibleNum / ItemManagerAction.Instance.m_combustibleMaxNum,
                    1f);

        DOTween.To(() => ItemManagerAction.Instance.m_plasticGauge.value,
                    num => ItemManagerAction.Instance.m_plasticGauge.value = num,
                    ItemManagerAction.Instance.m_plasticNum / ItemManagerAction.Instance.m_plasticMaxNum,
                    1f);
        DOTween.To(() => ItemManagerAction.Instance.m_oversizeGauge.value,
                    num => ItemManagerAction.Instance.m_oversizeGauge.value = num,
                    ItemManagerAction.Instance.m_oversizeNum / ItemManagerAction.Instance.m_plasticMaxNum,
                    1f);
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
