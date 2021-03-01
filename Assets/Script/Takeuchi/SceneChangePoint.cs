using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangePoint : MonoBehaviour
{
    [SerializeField]
    int target = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            SceneChangeControl.SceneChange(target);
        }
    }
}
