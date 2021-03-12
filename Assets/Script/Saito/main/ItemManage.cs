using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    public static ItemManage Instance { get; private set; }
    #region アイテムごとに必要なクラフト素材
    public List<ItemData> AluminiumKnifeCraft = new List<ItemData> { ItemData.AluminumCan, ItemData.PieceOfCloth };
    public List<ItemData> FragileKnifeCraft = new List<ItemData> { ItemData.BrokenBottle, ItemData.Aluminium };
    public List<ItemData> SmallKnifeCraft = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> MacheteCraft = new List<ItemData> { ItemData.KnifeCore, ItemData.FragmentOfOre, ItemData.Wood };
    public List<ItemData> Pickaxe1Craft = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> Pickaxe2Craft = new List<ItemData> { ItemData.PickaxeCore, ItemData.BearClaws,ItemData.DurableBranches };
    public List<ItemData> TrapCraft = new List<ItemData> { ItemData.Straw, ItemData.SuppleBranches };
    public List<ItemData> AxeCraft = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> HammerCraft = new List<ItemData> { ItemData.AxeCore, ItemData.HardOre };
    public List<ItemData> BridgeCraft = new List<ItemData> { ItemData.Wood, ItemData.Wood, ItemData.Wood, ItemData.Wood, ItemData.Wood, ItemData.DurableIvy, ItemData.DurableIvy, ItemData.DurableIvy, ItemData.DurableIvy, ItemData.DurableIvy };
    public List<ItemData> FireCraft = new List<ItemData> { ItemData.DeadBranch, ItemData.Straw };
    #endregion

    #region アイテムを分解すると手に入る素材
    public ItemData amallKnefeDisassembly = ItemData.KnifeCore;
    public ItemData pickaxe1Disassembly = ItemData.PickaxeCore;
    public ItemData aluminiumKnifeDisassembly = ItemData.Aluminium;
    public ItemData fragileKnifeDisassembly = ItemData.IronPiece;
    public ItemData axeDisassembly = ItemData.AxeCore;
    #endregion

    public Dictionary<ItemData, int> itemList = new Dictionary<ItemData, int>()
    {
        #region ディクショナリーの初期化
        {ItemData.Chicken,0 },
        {ItemData.Venison,0 },
        {ItemData.BakedChicken,0 },
        {ItemData.Jibie,0 },
        {ItemData.WaterBottle,0 },
        {ItemData.Herbs,0 },
        {ItemData.HealingDrug,0 },
        {ItemData.EndMaterial,0 },
        {ItemData.PetBottles,0 },
        {ItemData.BrokenBottle,0 },
        {ItemData.AluminumCan,0 },
        {ItemData.PieceOfCloth,0 },
        {ItemData.Stone,0 },
        {ItemData.DeadBranch,0 },
        {ItemData.Straw,0 },
        {ItemData.SuppleBranches,0 },
        {ItemData.DurableBranches,0 },
        {ItemData.IronPiece,0 },
        {ItemData.BearClaws,0 },
        {ItemData.FragmentOfOre,0 },
        {ItemData.HardOre,0 },
        {ItemData.DurableIvy,0 },
        {ItemData.Wood,0 },
        {ItemData.Aluminium,0 },
        {ItemData.KnifeCore,0 },
        {ItemData.PickaxeCore,0 },
        {ItemData.AxeCore,0 },
        {ItemData.AluminiumKnife,0 },
        {ItemData.FragileKnife,0 },
        {ItemData.SmallKnife,0 },
        {ItemData.Machete,0 },
        {ItemData.Pickaxe1,0 },
        {ItemData.Pickaxe2,0 },
        {ItemData.Trap,0 },
        {ItemData.Axe,0 },
        {ItemData.Hammer,0 },
        {ItemData.Bridge,0 },
        {ItemData.Fire,0 }
        #endregion
    };
    private void Start()
    {
        Instance = this;
        Debug.Log(itemList.Count);
        
    }
    public void GetItem(ItemData item)
    {
        if (itemList[item] == 0)
        {
            itemList[item]++;
        }
        else if((int)item >= (int)ItemData.AluminiumKnife)
        {
            Debug.Log("複数作成することは出来ません");
        }
    }
    
}
