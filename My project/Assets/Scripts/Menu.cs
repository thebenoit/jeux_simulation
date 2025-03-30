using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{
    public float Vitesse;
    public float Acceleration;

    // Start is called before the first frame update
    public static Menu Instance {get;} = new Menu();

    // Update is called once per frame
    private Menu()
    {

    }
}
