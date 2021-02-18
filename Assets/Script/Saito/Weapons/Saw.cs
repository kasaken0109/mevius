using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : WeaponBase
{
    bool clearFlag = true;
    private void Start()
    {
        EnduranceValue = 2;
        AttackPoint = 3;
        RequiredWoodValue = 1;
        RequiredMetalValue = 2;
    }
}
