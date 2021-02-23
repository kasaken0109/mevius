using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    [SerializeField]
    private int materialType = 0;
    [SerializeField]
    private float moveTime = 0.5f;
    private float startMoveTimer;
    [SerializeField]
    private float moveSpeed = 5.0f;
    Vector3 moveDir = Vector3.zero;
    private bool xxx;
    private bool zzz;
    private float stayTime;
    private float earthPosY;
    void Update()
    {
        if (startMoveTimer > 0)
        {
            startMoveTimer -= Time.deltaTime;
            transform.position += moveDir * moveSpeed * 2 * Time.deltaTime;
            xxx = true;
        }
        else if (xxx && stayTime < 0.08f)
        {
            if (!zzz)
            {
                transform.position -= new Vector3(0, moveSpeed * 2 * Time.deltaTime);
                if (transform.position.y <= earthPosY)
                {
                    zzz = true;
                }
            }
            else
            {
                stayTime += Time.deltaTime;
            }
        }
        else
        {
            moveDir = Player.Instance.transform.position - transform.position;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
    
    public void StartMove(Vector3 createPosition, Vector3 moveDir)
    {
        this.moveDir = moveDir;
        transform.position = createPosition;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, moveDir);
        startMoveTimer = moveTime;
        earthPosY = createPosition.y - 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (startMoveTimer <= 0 && zzz)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                MaterialManager.Instance.AddMaterial(materialType);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (startMoveTimer <= 0 && zzz)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                MaterialManager.Instance.AddMaterial(materialType);
                Destroy(this.gameObject);
            }
        }
    }
}
