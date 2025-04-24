using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private Villageois villageois;

    private void Start()
    {
        villageois = GameObject.FindObjectOfType<Villageois>();

    }

    public void ChoixHasard()
    {
        villageois.ChangerStrategieChoix(new StrategieChoixHasard());
        PlayerPrefs.SetInt("strategie", 3);
    }

    public void ChoixPlusProche()
    {
        villageois.ChangerStrategieChoix(new StrategieChoixPlusProche());
        PlayerPrefs.SetInt("strategie", 1);    
    }

    public void ChoixEquilibre()
    {
        villageois.ChangerStrategieChoix(new StrategieChoixEquilibre());
        PlayerPrefs.SetInt("strategie", 2);
    }
}