using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance { get; private set; }
    [SerializeField]
    public GameObject[] dropMaterialsPrefab;
    [SerializeField]
    private int[] haveMaterials;
    private void Awake()
    {
        Instance = this;
    }
    public void AddMaterial(int materialType)
    {
        haveMaterials[materialType]++;
    }
    public void UseMaterial(int materialType,int useNumber)
    {
        if (haveMaterials[materialType] >= useNumber)
        {
            haveMaterials[materialType] -= useNumber;
        }
        else
        {
            Debug.Log("素材不足");
        }
    }
}
