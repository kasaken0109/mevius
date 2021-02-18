using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : WeaponBase
{
    private void Start()
    {
        EnduranceValue = 2;
        AttackPoint = 1;
        RequiredWoodValue = 1;
        RequiredMetalValue = 0;
    }
    public void Craft()
    {
        if (ItemManager.woodNumber >= RequiredWoodValue)
        {
            ItemManager.woodNumber -= RequiredWoodValue;
        }
    }
}
