using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    CommandType type = CommandType.GetTool;
    [SerializeField]
    GameObject ObstacleObject;
    private void Start()
    {
        ObstacleObject.SetActive(false);
    }
    public void BreakObstacle(CommandType type)
    {
        if (type == this.type)
        {
            ObstacleObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void Open()
    {
        ObstacleObject.SetActive(true);
    }
}
