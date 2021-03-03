using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerAction : MonoBehaviour
{
    [SerializeField] float m_kanGauge;
    [SerializeField] float m_petGauge;
    
    public void GetItem(ItemAction.Materal materal)
    {
        if (materal == ItemAction.Materal.Kan)
        {
            m_kanGauge++;
        }
        if (materal == ItemAction.Materal.Petbottle)
        {
            m_petGauge++;
        }
    }
}
