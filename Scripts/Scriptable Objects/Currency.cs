using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency Type", menuName = "Economy/Currency Type")]
public class Currency : ScriptableObject
{

    public string currencyName;
    public string abriviation;
    public int value;

}
