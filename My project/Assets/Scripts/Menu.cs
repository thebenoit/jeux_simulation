using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{
    /// <summary>
    /// L'instance statique du singleton
    /// </summary>
    public static Menu Instance {get;} = new Menu();

    /// <summary>
    /// La vitesse du personnage
    /// </summary>
    public int Vitesse {set; get;} = 15;

    /// <summary>
    /// L'accélération du personnage
    /// </summary>
    public int Acceleration {set; get;} = 15;    

    // Update is called once per frame
    private Menu()
    {

    }
}
