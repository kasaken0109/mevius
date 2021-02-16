using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBase : MonoBehaviour
{
    /// <summary>マップ全体のX座標最大値</summary>
    [SerializeField] private int mapSizeX = 10;
    /// <summary>マップ全体のY座標最大値</summary>
    [SerializeField] private int mapSizeY = 10;
    /// <summary>マス目の大きさ</summary>
    [SerializeField] private float squresSize = 10.0f;
    /// <summary>確認用仮パネルデータ
    [SerializeField] GameObject panel = null;
    public static MapBase Instance { get; private set; }//マップ情報の取得を可能にする
    /// <summary>
    /// マス目のデータ
    /// </summary>
    public class SquaresData
    {
        public int PosX { get; private set; }//X座標
        public int PosY { get; private set; }//Y座標
        public bool NoIntrusion { get; private set; }//trueで侵入不可
        public Player Character { get; private set; }//キャラクター情報の入れ物、型は仮でPlayer
        /// <summary> アイテムの入れ物　</summary>
        public ItemBase Item { get; private set; }
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
        public void OnCharacter(Player character)
        {
            Character = character;
            NoIntrusionTrue();
        }
        public void OutCharacter()
        {
            Character = null;
            IntrusionTrue();
        }
        /// <summary>
        /// アイテムを受け取り配置する
        /// </summary>
        /// <param name="item">配置アイテム</param>
        public void OnItem(ItemBase item)
        {
            Item = item;
        }
        public void OutItem()
        {
            Item = null;
        }
    }
    /// <summary>マップの全マス目情報</summary>
    public List<SquaresData> MapData { get; private set; }
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
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
    /// 指定したマス目の情報を返す
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public SquaresData GetSquaresData(int x,int y)
    {
        if (x < mapSizeX && y < mapSizeY && x >= 0 && y >= 0)
        {
            return MapData[x + y * mapSizeX];
        }
        else
        {
            return null;
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
        if (x < mapSizeX && y < mapSizeY && x >= 0 && y >= 0)
        {
            return MapData[x + y * mapSizeX].NoIntrusion;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 指定したマス目にアイテムを配置する
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <param name="item">配置アイテム</param>
    public void SetItemOnSquares(int x,int y,ItemBase item)
    {
        if (x < mapSizeX && y < mapSizeY && x >= 0 && y >= 0)
        {
            MapData[x + y * mapSizeX].OnItem(item);
        }
    }
    /// <summary>
    /// 指定したマス目にアイテムがあれば取得する
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void GetItemOnSquares(int x,int y)
    {
        if (x < mapSizeX && y < mapSizeY && x >= 0 && y >= 0)
        {
            if (MapData[x + y * mapSizeX].Item)
            {
                MapData[x + y * mapSizeX].Item.GetItem();
                MapData[x + y * mapSizeX].OutItem();
                Debug.Log("アイテム取得");
            }
        }
    }
    public int GetMapMaxX() { return mapSizeX; }
    public int GetMapMaxY() { return mapSizeY; }
    public float GetSquaresSize() { return squresSize; }
}
