using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "Economy/Person")]
public class Person : ScriptableObject
{
    public string personName;
    public int personAge;
    public Person Spouse;
    public Business businessWorkAt;
    public SocialRanking socialRanking;
    public EmploymentStatus employmentStatus;
    public PersonState personState;
    //Mood
    //Work ethic??? or how they work at work

    public int riskFactor;

    public List<WalletSlot> wallet = new List<WalletSlot>();
    public List<InventorySlot> inventory = new List<InventorySlot>();

    public void Awake()
    {
        //Risk factor determines how risky the person will be in making desitions
        riskFactor = Random.Range(1, 10);
        personState = PersonState.Relaxing;
    }

    public void Logic()
    {
        //Logic Function allows the person to make there own desition, relax, work hard at work (or not), buy stuff or even make there own buisness

        //If they work
            //Manufacture products quality will be affected by how hard they work
                //Assign a weight to it
        if(personState == PersonState.isWorking)
        {

        }

        //Not working
            //Shopping
                //Desireable items
                    //Essentials
                        //Food
                        //Furniture
                        //Housing
                //Luxury items
                    //Makes desition if they have the money to buy it
                    //Risk factor
                    //If they can offord it Logic (The hardest part)
                        //Expendeable money = Total income - Essential Expenses
                        //if furniture, do they have room in the hosue?
                        //Most likely to buy items that are related to there social status

    }

    public void PersonalLife()
    {

    }

    public void AddMoney(Currency _currency, int _amount)
    {
        bool hasCurrency = false;
        for (int i = 0; i < wallet.Count; i++)
        {
            if (wallet[i].currency == _currency)
            {
                wallet[i].AddAmount(_amount);
                hasCurrency = true;
                break;
            }
        }
        if (!hasCurrency)
        {
            wallet.Add(new WalletSlot(_currency, _amount));
        }
    }

    public void AddGoods(Goods _item, int _amount)
    {
        bool hasCurency = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].item == _item)
            {
                inventory[i].AddAmount(_amount);
                hasCurency = true;
                break;
            }
        }
        if (!hasCurency)
        {
            inventory.Add(new InventorySlot(_item, _amount));
        }
    }
}


[System.Serializable]
public class WalletSlot
{
    public Currency currency;
    public int amount;
    public WalletSlot(Currency _currency, int _amount)
    {
        currency = _currency;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}

[System.Serializable]
public class InventorySlot
{
    public Goods item;
    public int amount;
    public InventorySlot(Goods _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
