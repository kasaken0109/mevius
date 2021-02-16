using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    /// <summary>使用回数</summary>
    public int EnduranceValue { get; set; }
    /// <summary>攻撃力</summary>
    public int AttackPoint { get; set; }
    /// <summary>木材の必要数</summary>
    public int RequiredWoodValue { get; set; }
    /// <summary>鉄の必要数</summary>
    public int RequiredMetalValue { get; set; }

    public WeaponBase GetWeapon() { return this; }
}
