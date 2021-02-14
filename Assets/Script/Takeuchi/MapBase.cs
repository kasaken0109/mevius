using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBase : MonoBehaviour
{
    [SerializeField]
    private int mapSizeX;//マップ全体のX座標最大値
    [SerializeField]
    private int mapSizeY;//マップ全体のY座標最大値
    [SerializeField]
    private float squresSize;//マス目の大きさ
    [SerializeField]
    GameObject panel = null;//確認用仮パネルデータ
    /// <summary>
    /// マス目のデータ
    /// </summary>
    public class SquaresData
    {
        public int PosX { get; private set; }//X座標
        public int PosY { get; private set; }//Y座標
        public bool NoIntrusion { get; private set; }//trueで侵入不可
        public int movePoint = 0;//距離計算用仮データ
        /// <summary>
        /// 初期設定用コンストラクタ
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        public SquaresData(int x,int y)
        {
            PosX = x;
            PosY = y;
        }
        /// <summary>
        /// 侵入不可にする
        /// </summary>
        public void NoIntrusionTrue()
        {
            NoIntrusion = true;
        }
        /// <summary>
        /// 侵入不可を解除
        /// </summary>
        public void IntrusionTrue()
        {
            NoIntrusion = false;
        }
    }
    public List<SquaresData> MapData { get; private set; }//マップの全マス目情報
    private void Awake()
    {
        MapCreate(mapSizeX, mapSizeY);
    }
    /// <summary>
    /// マップデータの生成
    /// </summary>
    /// <param name="maxX">X座標最大値</param>
    /// <param name="maxY">Y座標最大値</param>
    private void MapCreate(int maxX, int maxY)
    {
        MapData = new List<SquaresData>();
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                SquaresData squares = new SquaresData(x, y);
                MapData.Add(squares);
                //確認用仮パネル配置
                GameObject mapPanel = Instantiate(panel);
                mapPanel.transform.position = new Vector2(x * squresSize, y * squresSize);
                mapPanel.transform.SetParent(transform);
            }
        }
    }
    /// <summary>
    /// 指定したマス目が侵入不可か返す
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <returns></returns>
    public bool GetSquaresNoIntrusion(int x,int y)
    {
        return MapData[x + y * mapSizeX].NoIntrusion;
    }
}
