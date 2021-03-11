using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftData : MonoBehaviour
{
    public List<ItemData> aluminiumKnife = new List<ItemData> { ItemData.AluminumCan, ItemData.PieceOfCloth };
    public List<ItemData> fragileKnife = new List<ItemData> { ItemData.BrokenBottle, ItemData.Aluminium };
    public List<ItemData> smallKnife = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> machete = new List<ItemData> { ItemData.KnifeCore, ItemData.FragmentOfOre, ItemData.Wood };
    public List<ItemData> pickaxe1 = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> pickaxe2 = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> trap = new List<ItemData> { ItemData.Straw, ItemData.SuppleBranches };
    public List<ItemData> axe = new List<ItemData> { ItemData.IronPiece, ItemData.DurableBranches };
    public List<ItemData> hammer = new List<ItemData> { ItemData.AxeCore, ItemData.HardOre };
    public List<ItemData> bridge = new List<ItemData> { ItemData.Wood, ItemData.Wood, ItemData.Wood, ItemData.Wood, ItemData.Wood, ItemData.DurableIvy, ItemData.DurableIvy, ItemData.DurableIvy, ItemData.DurableIvy, ItemData.DurableIvy };
    public List<ItemData> fire = new List<ItemData> { ItemData.DeadBranch, ItemData.Straw };

}
