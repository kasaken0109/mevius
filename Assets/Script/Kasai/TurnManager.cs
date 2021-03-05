using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    /// <summary> ターン内の状態を表す</summary>
    public TurnName turnName;
    /// <summary> ゲーム内の状態を表す</summary>
    public GameState gameState;
    /// <summary> ターン数を表す</summary>
    [SerializeField] int m_turnNum = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.GAMESTART;
        //turnName = TurnName.PLAYERMOVE;
    }

    // Update is called once per frame
    void Update()
    {
        //if (turnName == TurnName.TURNEND)
        //{
        //    m_turnNum -= 1;
        //}
        //if (m_turnNum == 0)
        //{
        //    gameState = GameState.GAMEOVER;
        //    Debug.Log("GameOver");
        //}
    }

    /// <summary>
    /// ターン内の状態を表す
    /// </summary>
    public enum TurnName
    {
        PLAYER,
        ENEMY,
        FINISHED,
    }

    /// <summary>
    /// ゲームの状態を表す
    /// </summary>
    public enum GameState
    {
        GAMESTART,
        GAMEOVER,
        GAMECLER,
        STOP,
    }
}
