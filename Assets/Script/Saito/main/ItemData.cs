﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public enum ItemList
    {
        #region ステータス系
        ///<summary>鶏肉</summary>
        Chicken,
        ///<summary>鹿肉</summary>
        Venison,
        ///<summary>焼き鳥</summary>
        BakedChicken,
        ///<summary>ジビエ</summary>
        Jibie,
        ///<summary>水筒</summary>
        WaterBottle,
        ///<summary>薬草</summary>
        Herbs,
        ///<summary>治癒薬</summary>
        HealingDrug,
        #endregion

        #region 素材系
        ///<summary>ペットボトル</summary>
        PetBottles,
        ///<summary>割れたビン</summary>
        BrokenBottle,
        ///<summary>アルミ缶</summary>
        AluminumCan,
        ///<summary>布切れ</summary>
        PieceOfCloth,
        ///<summary>藁</summary>
        straw,
        ///<summary>しなやかな枝</summary>
        SuppleBranches,
        ///<summary>丈夫な枝</summary>
        DurableBranches,
        ///<summary>鉄片</summary>
        IronPiece,
        ///<summary>クマの爪</summary>
        BearClaws,
        ///<summary>鉱石のかけら</summary>
        FragmentOfOre,
        ///<summary>硬い鉱石</summary>
        HardOre,
        ///<summary>丈夫なツタ</summary>
        DurableIvy,
        ///<summary>木材</summary>
        Wood,
        ///<summary>アルミニウム</summary>
        Aluminium,
        ///<summary>ナイフの芯</summary>
        KnifeCore,
        ///<summary>ピッケルの芯</summary>
        PickaxeCore,
        ///<summary>斧の骨子</summary>
        AxeCore,
        #endregion

        #region クラフト系
        ///<summary>アルミナイフ</summary>
        AluminiumKnife,
        ///<summary>脆いナイフ</summary>
        FragileKnife,
        ///<summary>小型ナイフ</summary>
        SmallKnife,
        ///<summary>マチェータ</summary>
        Machete,
        ///<summary>ピッケル1</summary>
        Pickaxe1,
        ///<summary>ピッケル2</summary>
        Pickaxe2,
        ///<summary>罠</summary>
        Trap,
        ///<summary>斧</summary>
        Axe,
        ///<summary>ハンマー</summary>
        Hammer,
        ///<summary>橋</summary>
        Bridge,
        ///<summary>火</summary>
        Fire,
        #endregion
        ///<summary>端材</summary>
        EndMaterial
    }
}
