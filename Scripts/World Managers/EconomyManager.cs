using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{

    TimeManager timeManager;

    public Currency[] curencyInCirculation;
    public Goods[] goodsAvailable;
    public Person[] peopleInTheWorld;
    public Business[] businessesInTheWorld;
    public House[] housesInTheWorld;

    int i;
    int moneyValue; //0-4
    int moneyMultiplyer;

    private void Awake()
    {
        //Gives some money to people at start based on there social ranking on start
        for (i = 0; i < peopleInTheWorld.Length; i++)
        {
            //peopleInTheWorld[i].
            if (peopleInTheWorld[i].socialRanking == SocialRanking.Poor)
            {
                AddCurency(0, 5);
            }
            if (peopleInTheWorld[i].socialRanking == SocialRanking.LowerMiddleClass)
            {
                AddCurency(1, 5);
            }
            if (peopleInTheWorld[i].socialRanking == SocialRanking.UpperMiddleClass)
            {
                AddCurency(2, 5);
            }
            if (peopleInTheWorld[i].socialRanking == SocialRanking.Rich)
            {
                AddCurency(3, 5);
            }


            //Hiring system?
            /*
            for (int v = 0; v < businessesInTheWorld.Length; v++)
            {
                if (peopleInTheWorld[i].employmentStatus = EmploymentStatus.lookingForWork)
                {
                    businessesInTheWorld[v].BuisnessWorkers(peopleInTheWorld[i], JobTitle.Apprentice);
                }

                businessesInTheWorld[i].buisnessMoney = curencyInCirculation;
            }
            */
        }

        //Does things for buisnesses

    }


    //Adding money without work
    void AddCurency(int moneyValue, int moneyAmmount)
    {
        peopleInTheWorld[i].AddMoney(curencyInCirculation[moneyValue], moneyAmmount); 
    }

    //Adds goods to person / not work related
    void AddGoodToPerson(int goodsID, int amountOfGoods)
    {
        peopleInTheWorld[i].AddGoods(goodsAvailable[goodsID], amountOfGoods);
    }

}
