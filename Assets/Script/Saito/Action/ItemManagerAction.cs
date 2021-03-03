using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ItemManagerAction : MonoBehaviour
{
    public float m_kanNum;
    public float m_kanMaxNum = 3;
    public float m_petNum;
    public float m_petMaxNum = 3;
    public Slider m_kanGauge = null;
    public Slider m_petGauge = null;
    public static ItemManagerAction Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
}
