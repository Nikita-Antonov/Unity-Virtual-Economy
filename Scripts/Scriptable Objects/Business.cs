using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buisness", menuName = "Economy/Buisness")]
public class Business : ScriptableObject
{
    TimeManager timeManager;
    EconomyManager economyManager;
    JobTitle jobtitles;

    public string buisnessName;

    public Person companyFounder;
    public Person CEO;

    public Currency[] buisnessMoney;
    public Person[] currentNumberOfWorkers;
    public int prefferedCurrencyUnit = 1;

    public bool lookingToHire = true;

    public int workStart = 9;
    public int workEnd = 17;
    public int payout;

    //Job Position list of people working in the company
    public List<BuisnessWorkers> buisnessWorkers = new List<BuisnessWorkers>();
    //List of the money and its type that is curently in the possetion of the buisness
    public List<BuissnessBankAccount> buissnessBankAccount = new List<BuissnessBankAccount>();
    //The inventory the buisness owns,  either for warehouse of sale
    public List<BuisnessInventory> buisnessInventory = new List<BuisnessInventory>();

    public void Logic()
    {

    }

    public void HireWorker()
    {

    }

    public void WorkDay()
    {
        if(timeManager.currentHour == workStart)
        {
            for (int i = 0; i < currentNumberOfWorkers.Length; i++)
            {
                currentNumberOfWorkers[i].personState = PersonState.isWorking;
            }
        }

        if(timeManager.currentHour == workEnd)
        {

            for (int i = 0; i < currentNumberOfWorkers.Length; i++){

                if (currentNumberOfWorkers[i].personState == PersonState.isWorking)
                {
                    currentNumberOfWorkers[i].personState = PersonState.notWorking;

                    /*Add Paymebnt based on job title, i added it to the worker class, and really need to get to work on the hiring part
                     * Here is how it could work,
                     * 
                     * mamagers have a certain amnount of workers they can keep track off
                     * hire accorfding to the amount of managers compared to profits compared to sales
                     * 
                     * So sales need to be made
                     * for that people need to buy stuff
                     * 
                     * Add buisness manufacturuing
                     * add buisness buying raw resoruses
                     * raw resource gathering buisnessses
                     * 
                     * Check out the Hiring System in the economty manager
                     */

                    currentNumberOfWorkers[i].AddMoney(buisnessMoney[prefferedCurrencyUnit], payout);
                    RemoveMoneyFromBuissness(buisnessMoney[prefferedCurrencyUnit], payout);
                }
            }
           
        }
    }

    public void RemoveMoneyFromBuissness(Currency _currency, int _amount)
    {
        bool hasCurrency = false;
        for (int i = 0; i < buissnessBankAccount.Count; i++)
        {
            if (buissnessBankAccount[i].currency == _currency)
            {
                buissnessBankAccount[i].RemoveAmount(buisnessMoney[prefferedCurrencyUnit], payout);
                hasCurrency = true;
                break;
            }
        }
        if (!hasCurrency)
        {
            for (int i = 0; i < buissnessBankAccount.Count; i++)
            {
                int exchangeMultiplyer = 10;
                bool hasExcange = false;
                int unitDealingWith = prefferedCurrencyUnit++;
                if (buissnessBankAccount[i].currency == buisnessMoney[unitDealingWith])
                {
                    buissnessBankAccount[i].RemoveAmount(buisnessMoney[unitDealingWith], 1);
                    buissnessBankAccount[i].AddAmount(buisnessMoney[prefferedCurrencyUnit], 10 * exchangeMultiplyer);
                    hasExcange = true;
                    break;
                }

                /*
                 * I guess this is all working, but i have no idea
                 * above is code for a base for the curency exchange, but there are thigns im not sure of
                 * 
                 * Future me, can you please run over this and make sure that its alright, 
                 * which will probably be within the next 24 hours, so good luch dude, i know you need it a lot
                 * as of now, there is still the mechanics of:
                 * 
                 * -Manufacturing
                 * -Worksers having affect on production
                 * -Workers Experience
                 * -Workers schedual
                 * -Selling the stock
                 * -Persons generator, so that i can have more than Matt Smith in the simulation (He is still best doctor)
                 * -Actually getting the economy to fucking work
                 *      aka, making a bunch of numbers understand what
                 *      Money is, its power and simulate a day to day life
                 */

                }
                //buissnessBankAccount.Remove(new BuissnessBankAccount(_curency, _amount));
            }
    }

    //Adds money to the buisness account for payout and other expenses
    public void AddMoneyToBuissness(Currency _currency, int _amount)
    {
        bool hasCurency = false;
        for (int i = 0; i < buissnessBankAccount.Count; i++)
        {
            if (buissnessBankAccount[i].currency == _currency)
            {
                buissnessBankAccount[i].AddAmount(_currency, _amount);
                hasCurency = true;
                break;
            }
        }
        if (!hasCurency)
        {
            buissnessBankAccount.Add(new BuissnessBankAccount(_currency, _amount));
        }
    }

    //Adds goods to the buisness inventory
    public void AddGoodsToBuissness(Goods _item, int _amount)
    {
        bool HasGood = false;
        for (int i = 0; i < buisnessInventory.Count; i++)
        {
            if (buisnessInventory[i].item == _item)
            {
                buisnessInventory[i].AddAmount(_amount);
                HasGood = true;
                break;
            }
        }
        if (!HasGood)
        {
            buisnessInventory.Add(new BuisnessInventory(_item, _amount));
        }
    }

    public void BuisnessWorkers(Person _worker, JobTitle _jobTitle)
    {
        bool HasWorker = false;
        for (int i = 0; i < buisnessWorkers.Count; i++)
        {
            if (buisnessWorkers[i].worker == _worker)
            {
                HasWorker = true;
                break;
            }
        }
        if (!HasWorker)
        {
            buisnessWorkers.Add(new BuisnessWorkers(_worker, _jobTitle));
        }
    }
}
[System.Serializable]
public class BuissnessBankAccount
{
    public Currency currency;
    public int amount;
    public BuissnessBankAccount(Currency _currency, int _amount)
    {
        currency = _currency;
        amount = _amount;
    }
    public void AddAmount(Currency _currency, int value)
    {
        currency = _currency;
        amount += value;
    }
    public void RemoveAmount(Currency _currency, int value)
    {
        currency = _currency;
        amount -= value;
    }
}

//Inventory
[System.Serializable]
public class BuisnessInventory
{
    public Goods item;
    public Currency currency;
    public int itemsValue;
    public int amount;
    public BuisnessInventory(Goods _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    //For selling items, please update the whole item reciving thing for this as well as the persons script, thnx
    public void RemoveItem(Goods _item, Currency _currency, int _itemValue, int _amount)
    {

    }
}

[System.Serializable]
public class BuisnessWorkers
{
    public Person worker;
    public JobTitle jobTitle;

    public BuisnessWorkers(Person _worker, JobTitle _jobTitle)
    {
        worker = _worker;
        jobTitle = _jobTitle;
    }
}