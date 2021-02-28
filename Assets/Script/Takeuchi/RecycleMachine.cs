using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecycleMachine : MonoBehaviour
{
    public void DropMaterial(int[] materialList)
    {
        int angleNumber = materialList.Sum();
        float allAngle = 90f / angleNumber;
        float span = -45f + allAngle / 2;
        for (int i = 0; i < materialList.Length; i++)
        {
            if (materialList[i] > 0)
            {
                float angleSpan = allAngle * materialList[i];
                for (int j = 0; j < materialList[i]; j++)
                {
                    GameObject instance = Instantiate<GameObject>(MaterialManager.Instance.dropMaterialsPrefab[i]);
                    Material material = instance.GetComponent<Material>();
                    material.StartMove(transform.position, GetDirection( allAngle * j + span));
                }
                span += angleSpan;
            }
        }
        
    }

    Vector3 GetDirection(float angle)
    {
        return new Vector3
        (
            Mathf.Sin(angle * Mathf.Deg2Rad),
            Mathf.Cos(angle * Mathf.Deg2Rad),
            0.0f
        ).normalized;
    }
}
