using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ItemManagerAction : MonoBehaviour
{
    /// <summary>現在の可燃ゴミの所持数</summary>
    public float m_combustibleNum;
    /// <summary>可燃ゴミの最大所持数</summary>
    public float m_combustibleMaxNum = 3;
    /// <summary>可燃ゴミの消費量</summary>
    public float m_combustibleConsumption = 1;
    /// <summary>現在のプラスチックの所持数</summary>
    public float m_plasticNum;
    /// <summary>プラスチックの最大所持量</summary>
    public float m_plasticMaxNum = 3;
    /// <summary>プラスチックの消費量</summary>
    public float m_plasticConsumption = 1;
    /// <summary>現在の粗大ごみの所持数</summary>
    public float m_oversizeNum;
    /// <summary>粗大ごみの最大所持数</summary>
    public float m_oversizeMaxNum = 3;
    /// <summary>粗大ごみの消費量</summary>
    public float m_oversizeConsumption = 3;

    public Slider m_combustibleGauge = null;
    public Slider m_plasticGauge = null;
    public Slider m_oversizeGauge = null;
    public static ItemManagerAction Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    public bool UseCombustibleGauge(float Consumption)
    {
        Instance.m_combustibleNum -= Consumption;

        if (Instance.m_combustibleNum >= Consumption)
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
    public bool UsePlasticGauge(float Consumption)
    {
        if (Instance.m_plasticNum >= Consumption)
        {
            Instance.m_plasticNum -= Consumption;
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
    public bool UseOversizeGauge(float Consumption)
    {
        Instance.m_oversizeNum -= Consumption;
        if (Instance.m_oversizeNum >= Consumption)
        {
            DOTween.To(() => Instance.m_oversizeGauge.value,
                        num => Instance.m_oversizeGauge.value = num,
                        Instance.m_oversizeNum / Instance.m_oversizeMaxNum,
                        1f);
            return true;
        }
        else
        {
            return false;
        }
    }
}
