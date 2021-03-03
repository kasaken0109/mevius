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
            if (this.type == Materal.Kan)
            {
                ItemManagerAction.Instance.m_kanNum++;
            }
            else if (this.type == Materal.Petbottle)
            {
                ItemManagerAction.Instance.m_petNum++;
            }
            GetItem();
            Destroy(this.gameObject);
        }
    }
    public void GetItem()
    {
        DOTween.To(() => ItemManagerAction.Instance.m_kanGauge.value,
        num =>
        {
            ItemManagerAction.Instance.m_kanGauge.value = num;
        },
        (float)ItemManagerAction.Instance.m_kanNum / ItemManagerAction.Instance.m_kanMaxNum,
        1f);

        DOTween.To(() => ItemManagerAction.Instance.m_petGauge.value,
        num =>
        {
            ItemManagerAction.Instance.m_petGauge.value = num;
        },
        (float)ItemManagerAction.Instance.m_petNum / ItemManagerAction.Instance.m_petMaxNum,
        1f);

    }
}
