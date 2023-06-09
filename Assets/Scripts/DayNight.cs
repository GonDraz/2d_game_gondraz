using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // using text mesh for the clock display

using UnityEngine.Rendering; // used to access the volume component

public class DayNight : MonoBehaviour
{
    [Header("Settings")]
    public Volume ppv; // this is the post processing volume
    public float tick; // Increasing the tick, increases second rate

    [Header("Time")]
    public float seconds;
    public int mins;
    public int hours;

    [Header("Light")]
    public bool activateLights; // checks if lights are on
    public GameObject[] sunLights; // all the sun lights 
    public GameObject[] lights; // all the lights we want on when its dark

    #region MonoBehaviour Callbacks
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        if (!GameController.Instance.pasueSystem)
        {
            CalcTime();
        }
    }
    #endregion

    #region Private Methor
    private void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
        }
        if (mins >= 60) //60 min = 1 hr
        {
            mins = 0;
            hours += 1;
        }
        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
        }
        ControlPPV(); // changes post processing volume after calculation
    }

    private void ControlPPV() // used to adjust the post processing slider.
    {
        if (hours >= 17 && hours < 18) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            for (int i = 0; i < sunLights.Length; i++)
            {
                sunLights[i].SetActive(false);
            }                       
        }

        //ppv.weight = 0;
        if (hours >= 19 && hours < 20) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            ppv.weight = (float)mins / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 

            if (activateLights == false) // if lights havent been turned on
            {
                if (mins > 45) // wait until pretty dark
                {           
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // turn them all on
                    }
                    activateLights = true;
                }
            }
        }

        if (hours >= 6 && hours < 7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            ppv.weight = 1 - (float)mins / 60; // we minus 1 because we want it to go from 1 - 0
            if (activateLights == true) // if lights are on
            {
                if (mins > 45) // wait until pretty bright
                {
                    for (int i = 0; i < sunLights.Length; i++)
                    {
                        sunLights[i].SetActive(true); // shut them off
                    }                    
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // shut them off
                    }
                    activateLights = false;
                }
            }
        }
    }
    #endregion
}
