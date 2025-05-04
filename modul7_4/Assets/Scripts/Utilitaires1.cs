using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilitaires1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int PlusGrandElementTableau(int[] tableau)
    {
        int plusGrand = tableau[0];
        for(int i = 1; i < tableau.Length; i++)
        {
            if(tableau[i] > plusGrand)
            {
                plusGrand = i;
            }
        }
        return plusGrand;
    }

    public static int PremierElementTableau(int[] tableau)
    {
       
        int premierElement = tableau[0];
        return premierElement;
    }
}
