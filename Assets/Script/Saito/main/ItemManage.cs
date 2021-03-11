using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    #region アイテムごとに必要なクラフト素材
    public List<ItemData> AluminiumKnifeCraft = new List<ItemData> { ItemData.AluminumCan, ItemData.PieceOfCloth };
    public List<ItemData> FragileKnifeCraft = new List<ItemData> { ItemData.BrokenBottle, ItemData.Aluminium };
    public List<ItemData> SmallKnifeCraft = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> MacheteCraft = new List<ItemData> { ItemData.KnifeCore, ItemData.FragmentOfOre, ItemData.Wood };
    public List<ItemData> Pickaxe1Craft = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> Pickaxe2Craft = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
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

    public Dictionary<ItemData, int> itemList = new Dictionary<ItemData, int>();
    private void Start()
    {
        Debug.Log(aluminiumKnifeDisassembly);
        itemList.Add(ItemData.Aluminium, 1);
        itemList[ItemData.Aluminium] += 2;
        Debug.Log(itemList[ItemData.Aluminium]);
    }
    public void GetItem(ItemData item)
    {
        if (itemList[item] == 0)
        {
            itemList.Add(item, 1);
        }
        else if((int)item >= (int)ItemData.AluminiumKnife)
        {
            Debug.Log("複数作成することは出来ません");
        }
        else
        {
            itemList[item]++;   
        }
    }
    public void CraftItem(ItemData result)
    {

    }
}
