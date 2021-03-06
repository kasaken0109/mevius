using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ItemManagerAction : MonoBehaviour
{
    /// <summary>現在の可燃ゴミの所持数</summary>
    public float m_combustibleNum;
    public float m_combustibleMaxNum = 3;
    /// <summary>現在のプラスチックの所持数</summary>
    public float m_plasticNum;
    public float m_plasticMaxNum = 3;
    /// <summary>現在の粗大ごみの所持数</summary>
    public float m_oversizeNum;
    public float m_oversizeMaxNum = 3;
    public Slider m_combustibleGauge = null;
    public Slider m_plasticGauge = null;
    public Slider m_oversizeGauge = null;
    public static ItemManagerAction Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    public bool UseKanGauge()
    {
        if (Instance.m_combustibleNum >= Instance.m_combustibleMaxNum)
        {
            DOTween.To(() => Instance.m_combustibleGauge.value,
                        num => Instance.m_combustibleGauge.value = num,
                        Instance.m_combustibleNum / Instance.m_combustibleMaxNum,
                        1f);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool UsePetGauge()
    {
        if (Instance.m_plasticNum >= Instance.m_plasticMaxNum)
        {
            DOTween.To(() => Instance.m_plasticGauge.value,
                        num => Instance.m_plasticGauge.value = num,
                        Instance.m_plasticNum / Instance.m_plasticMaxNum,
                        1f);
            return true;
        }
        else
        {
            return false;
        }
    }
}
