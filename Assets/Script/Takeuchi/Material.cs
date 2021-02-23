using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    
    private float startMoveTimer;
    [SerializeField]
    private float moveSpeed = 10.0f;
    void Update()
    {
        if (startMoveTimer > 0)
        {
            startMoveTimer -= Time.deltaTime;
            transform.localPosition = new Vector2(0, transform.localPosition.y + moveSpeed); 
        }
        else
        {
            
        }
    }
    
    public void StartMove(Quaternion angel)
    {
        transform.rotation = angel;
        startMoveTimer = 1.0f;
    }
}
