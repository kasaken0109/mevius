using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public static PlayerAction Instance { get; private set; }
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
    public bool directionLR;
    bool directionChange;
    bool onGround;
    bool firstPush;
    bool dash;
    float pushTimer = 0.3f;

    [SerializeField]
    int playerMaxHP = 100;
    public int PlayerCurrentHP { get; private set; }
    [SerializeField]
    int power = 5;
    [SerializeField]
    GameObject attack;
    float attackTimer;
    float attackPower = 30f;
    [SerializeField]
    GameObject collection;
    bool collect;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        directionLR = true;
        jumpCount = maxJumpCount;
        PlayerCurrentHP = playerMaxHP;
        attack.SetActive(false);
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
        if (!dash)
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                if (!firstPush)
                {
                    firstPush = true;
                    pushTimer = 0.3f;
                }
                else
                {
                    dash = true;
                }
            }
            else if (firstPush)
            {
                if (pushTimer > 0)
                {
                    pushTimer -= Time.deltaTime;
                }
                else
                {
                    firstPush = false;
                }
            }
        }
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
        if (Input.GetButtonDown("Attack") && attackTimer <= 0)
        {
            attack.SetActive(true);
            attackTimer = 0.2f;
            if (directionLR)
            {
                m_rb.AddForce(Vector2.right * attackPower, ForceMode2D.Impulse);
            }
            else
            {
                m_rb.AddForce(Vector2.right * -attackPower, ForceMode2D.Impulse);
            }
        }
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attack.SetActive(false);
            }
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            MoveStop();
            collection.SetActive(true);
            collect = true;
        }
        else if (collect)
        {
            collect = false;
            collection.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (dash)
                {
                    dir = Vector2.right * moveSpeed * 2f;
                }
                else
                {
                    dir = Vector2.right * moveSpeed;
                }
                if (!directionLR)
                {
                    directionLR = true;
                    directionChange = true;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (dash)
                {
                    dir = Vector2.right * -moveSpeed * 2f;
                }
                else
                {
                    dir = Vector2.right * -moveSpeed;
                }
                if (directionLR)
                {
                    directionLR = false;
                    directionChange = true;
                }
            }
            dir.y = m_rb.velocity.y;
            m_rb.velocity = dir;
        }
        else if(dash)
        {
            dash = false;           
            firstPush = false;
        }
        
    }

    public void MoveStop()
    {
        m_rb.velocity = Vector2.zero;
    }

    public void Damage(int damege)
    {
        PlayerCurrentHP -= damege;
    }
    public void Damage(int damege,Vector2 dir)
    {
        m_rb.AddForce(-dir * damege * 5f, ForceMode2D.Impulse);
        PlayerCurrentHP -= damege;
        Debug.Log(damege);
    }
    public void HPHealing(int healingPoint)
    {
        PlayerCurrentHP += healingPoint;
        if (PlayerCurrentHP > playerMaxHP)
        {
            PlayerCurrentHP = playerMaxHP;
        }
    }
    public int GetPlayerMaxHP() { return playerMaxHP; }
    public int GetPlayerPower() { return power; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
