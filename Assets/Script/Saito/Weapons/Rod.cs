using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : WeaponBase
{
    private void Start()
    {
        enduranceValue = 2;
        attackPoint = 1;
    }
    
    public Rod GetRod() { return this; }

}
