using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ワイヤーの挙動を制御する</summary>
public class WireManager : MonoBehaviour
{
    DistanceJoint2D m_joint;
    LineRenderer m_line;
    Collider2D m_hitObject = null;
    SpriteRenderer spriteRenderer;
    
    /// <summary> ワイヤー</summary>
    [SerializeField] float m_jointDistance = 10f;
    [SerializeField] float m_pullSpeed = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        m_joint = GetComponent<DistanceJoint2D>();
        m_line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_hitObject)
        {
            m_joint.enabled = true;
            m_joint.connectedBody = m_hitObject.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(m_joint.connectedBody);
            m_joint.connectedAnchor = new Vector2(m_hitObject.transform.position.x, m_hitObject.transform.position.y);
            m_joint.distance = Vector2.Distance(m_hitObject.transform.position, this.transform.position);
            //m_joint.connectedAnchor = m_hitObject.transform.position;
            //spriteRenderer = m_hitObject.gameObject.GetComponent<SpriteRenderer>();
            //spriteRenderer.color = Color.red;

        }

        if (Input.GetButton("Fire1") && m_joint.distance >= m_jointDistance && m_hitObject)
        {
            //Debug.Log("巻き取り");
            m_line.enabled = true;
            DrawLaser(m_hitObject.gameObject.transform.position);
            m_joint.distance -= m_pullSpeed;
        }
        else
        {
            //Debug.Log("切り離し");
            m_line.enabled = false;
            Debug.Log(m_joint.enabled);
            m_joint.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Joint")
        {
            //Debug.Log("入った！");
            m_hitObject = collision;
            Debug.Log(m_joint.distance);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Joint")
        {
            Debug.Log("入った！");
            m_hitObject = null;
        }
    }

    void DrawLaser(Vector3 destination)
    {
        Vector3[] positions = { m_line.transform.position, destination };   // レーザーの始点は常に Muzzle にする
        m_line.positionCount = positions.Length;   // Line を終点と始点のみに制限する
        m_line.SetPositions(positions);
    }
}
