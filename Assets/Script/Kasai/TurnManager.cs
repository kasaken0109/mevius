using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    /// <summary> ターン内の状態を表す</summary>
    public TurnName turnName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ターン内の状態を表す
    /// </summary>
    public enum TurnName
    {
        MOVE,
        ATTACK,
        ITEMMAKE,
    }
}
