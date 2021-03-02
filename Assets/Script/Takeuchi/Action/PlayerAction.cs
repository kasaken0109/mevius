using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Rigidbody2D m_rb;
    [SerializeField]
    float jumpPower = 1f;
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    LayerMask groundLayer = 0;
    [SerializeField]
    Vector2 rayForGround = Vector2.down;
    [SerializeField]
    int maxJumpCount = 2;
    int jumpCount = 0;
    bool directionLR;
    bool directionChange;
    bool onGround;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        directionLR = true;
        jumpCount = maxJumpCount;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayForGround, rayForGround.magnitude, groundLayer);
        if (hit.collider)
        {
            onGround = true;
            jumpCount = maxJumpCount;
        }
        else
        {
            onGround = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                m_rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            else if (jumpCount > 0)
            {
                m_rb.velocity = Vector2.zero;
                m_rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpCount--;
            }
        }
    }
    private void FixedUpdate()
    {

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                dir = Vector2.right * moveSpeed;
                if (!directionLR)
                {
                    directionLR = true;
                    directionChange = true;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                dir = Vector2.right * -moveSpeed;
                if (directionLR)
                {
                    directionLR = false;
                    directionChange = true;
                }
            }
            dir.y = m_rb.velocity.y;
            m_rb.velocity = dir;
            if (directionChange)
            {
                if (directionLR)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                directionChange = false;
            }
        }
    }
}
