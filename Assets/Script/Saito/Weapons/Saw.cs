using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : WeaponBase
{
    
    bool clearFlag = true;
    private void Start()
    {
        enduranceValue = 1;
        attackPoint = 2;
    }
    public Saw GetSaw() { return this; }
}
