using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New House", menuName = "Economy/House")]
public class House : ScriptableObject
{

    HouseZoning houseZoning;
    public int housePrice;

    //Add Pricing mechanic, that prices the house accourding to its room size and the inventory belingings

    public List<HouseInventory> houseInventory = new List<HouseInventory>();

    public void AddGoods(Goods _item, int _amount)
    {
        bool hasCurency = false;
        for (int i = 0; i < houseInventory.Count; i++)
        {
            if (houseInventory[i].item == _item)
            {
                houseInventory[i].AddAmount(_amount);
                hasCurency = true;
                break;
            }
        }
        if (!hasCurency)
        {
            houseInventory.Add(new HouseInventory(_item, _amount));
        }
    }

}

[System.Serializable]
public class HouseInventory
{
    public Goods item;
    public int amount;
    public HouseInventory(Goods _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
