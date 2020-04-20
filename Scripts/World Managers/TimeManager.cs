using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int currentHour;
    public int currentMinute;
    public int currentDate;

    public int maxHoursInDay = 24;
    public int maxMinutes = 60;

    [SerializeField] private float Timer = 0;
    [SerializeField] public float tickRate = 2.0f;

    public bool updated;

    private void Update()
    {
        WorldClock();
        //UserInteraction();
    }

    void UserInteraction()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            tickRate--;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            tickRate++;
        }

        //set tick rate limit to +4 and 1
    }

    void WorldClock()
    {
        //Game Rate
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
            updated = false;
        }
        if(Timer < 0)
        {
            Timer = 0;
        }
        if(Timer == 0)
        {
            currentMinute++;
            Timer = tickRate;
            updated = true;
            Debug.Log("Current Time: " + currentHour + ":" + currentMinute + " | " + currentDate);
        }

        //Clock Mechanics
        if(currentMinute == maxMinutes)
        {
            currentMinute = 0;
            currentHour++;
        }

        if(currentHour == maxHoursInDay)
        {
            currentHour = 0;
            currentDate++;
        }
    }
}
