using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    /// <summary>使用回数</summary>
    public int enduranceValue;
    /// <summary>攻撃力</summary>
    public int attackPoint;

    public virtual void BreakWeapon() { }
    public virtual WeaponBase GetWeapon() { return this; }
    
}
