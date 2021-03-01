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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
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
            Debug.Log("エラー");
        }
    }
    public void UseMaterial(int[] recipe)
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            if (haveMaterials[i] >= recipe[i])
            {
                haveMaterials[i] -= recipe[i];
            }
        }
    }
    public bool CheckMaterial(int[] recipe)
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            if(haveMaterials[i] < recipe[i])
            {
                return false;
            }
        }
        return true;
    }
}
