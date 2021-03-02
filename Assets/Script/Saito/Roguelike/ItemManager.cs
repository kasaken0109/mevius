using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    /// <summary> 木材の所持数 </summary>
    public static int woodNumber = 0;
    /// <summary> 鉄の所持数 </summary>
    public static int metalNumber = 0;
    [SerializeField] GameObject m_rodPrefab;
    [SerializeField] GameObject m_sawPrefab;
    [SerializeField] GameObject m_woodText;
    [SerializeField] GameObject m_metalText;
    
    public void CraftRod()
    {
        if (woodNumber >= CraftData.RodWoodValue && metalNumber >= CraftData.RodMetalValue)
        {
            Instantiate(m_rodPrefab, this.gameObject.transform);
            woodNumber -= CraftData.RodWoodValue;
            metalNumber -= CraftData.RodMetalValue;
            //ChangeText();
        }
    }
    public void CraftSaw()
    {
        if (woodNumber >= CraftData.SawWoodValue && metalNumber >= CraftData.SawMetalValue)
        {
            Instantiate(m_sawPrefab, this.gameObject.transform);
            woodNumber -= CraftData.SawWoodValue;
            metalNumber -= CraftData.SawMetalValue;
            //ChangeText();
        }
    }
    public void ChangeText()
    {
        Text woodText = m_woodText.GetComponent<Text>();
        woodText.text = woodNumber.ToString();

        Text metalText = m_metalText.GetComponent<Text>();
        metalText.text = metalNumber.ToString();
    }
}
