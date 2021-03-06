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
    public float m_combustibleMaxNum = 100;
    /// <summary>現在のプラスチックの所持数</summary>
    public float m_plasticNum;
    /// <summary>プラスチックの最大所持量</summary>
    public float m_plasticMaxNum = 100;
    /// <summary>現在の粗大ごみの所持数</summary>
    public float m_oversizeNum;
    /// <summary>粗大ごみの最大所持数</summary>
    public float m_oversizeMaxNum = 100;

    public Slider m_combustibleGauge = null;
    public Slider m_plasticGauge = null;
    public Slider m_oversizeGauge = null;
    private bool m_setCheck = false;
    public static ItemManagerAction Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        if (m_setCheck)
        {
            DOTween.To(() => m_combustibleGauge.value,
                    num => m_combustibleGauge.value = num,
                    m_combustibleNum / m_combustibleMaxNum,
                    1f);

            DOTween.To(() => m_plasticGauge.value,
                        num => m_plasticGauge.value = num,
                        m_plasticNum / m_plasticMaxNum,
                        1f);
            DOTween.To(() => m_oversizeGauge.value,
                        num => m_oversizeGauge.value = num,
                        m_oversizeNum / m_oversizeMaxNum,
                        1f);
            m_setCheck = false;
        }
    }
    public bool CheckCombustibleGauge(float Consumption)
    {
        if (m_combustibleNum >= Consumption)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckPlasticGauge(float Consumption)
    {
        if (m_plasticNum >= Consumption)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckOversizeGauge(float Consumption)
    {
        if (Instance.m_oversizeNum >= Consumption)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void UseCombustibleGauge(float Consumption)
    {
        m_oversizeNum -= Consumption;
        m_setCheck = true;
    }
    public void UsePlasticGauge(float Consumption)
    {
        m_oversizeNum -= Consumption;
        m_setCheck = true;
    }
    public void UseOversizeGauge(float Consumption)
    {
        m_oversizeNum -= Consumption;
        m_setCheck = true;
    }
    public void SetCombustible(float num)
    {
        m_combustibleNum += num;
        m_setCheck = true;
    }
    public void SetPlastic(float num)
    {
        m_plasticNum += num;
        m_setCheck = true;
    }
    public void SetOversize(float num)
    {
        m_oversizeNum += num;
        m_setCheck = true;
    }
}
