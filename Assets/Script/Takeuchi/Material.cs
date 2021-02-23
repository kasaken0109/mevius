using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    
    private float startMoveTimer;
    [SerializeField]
    private float moveSpeed = 5.0f;
    Vector3 moveDir = Vector3.zero;
    void Update()
    {
        if (startMoveTimer > 0)
        {
            startMoveTimer -= Time.deltaTime;
            transform.position += moveDir * moveSpeed * 2 * Time.deltaTime;
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
        startMoveTimer = 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            Destroy(this.gameObject);
        }
    }
}
