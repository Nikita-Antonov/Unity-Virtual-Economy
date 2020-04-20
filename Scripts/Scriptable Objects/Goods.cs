using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Goods", menuName = "Economy/Goods")]
public class Goods : ScriptableObject
{
    public new string name;
    public GoodsState goodsState;
    public GoodsGrade goodsGrade;
    public GoodsQuality goodsQuality;
    public Currency currency;
    public int goodsValue;
    public int numberOfItemGoods;
}
