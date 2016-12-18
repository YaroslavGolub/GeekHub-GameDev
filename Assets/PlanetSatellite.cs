using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlanetSatellite : MonoBehaviour
{

    public Transform Waypoint;
    private int day = 0;

    public YearCounter yearCounter;

    public bool watching;


    private Text dayText;
    private Text yearText;

    void Start()
    {
        watching = false;   
        dayText = GameObject.Find("DayTxt").GetComponent<Text>();
        yearText = GameObject.Find("YearTxt").GetComponent<Text>();
    }


    void Update()
    {
        if (!watching)
            return;

        UpdateText();

    }

    public void UpdateText()
    {
        dayText.text = "Days " + day;
        yearText.text = "Year " + yearCounter.GetCurrentYear();
    }

    public void CountDay()
    {
        day++;
    }
}
