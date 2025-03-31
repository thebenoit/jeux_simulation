using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    ///<summary>
    ///le champ saisie de vitesse
    ///</summary>
    ///
    [SerializeField] private TMP_InputField saisieVitesse;

    ///<summary>
    ///le champ saisie de l'accélération
    ///</summary>
    ///
    [SerializeField] private TMP_InputField saisieAcceleration;


    // Start is called before the first frame update
    void Start()
    {
        saisieVitesse.text = Menu.Instance.Acceleration.ToString();
        saisieAcceleration.text = Menu.Instance.Vitesse.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quitter()
    {
        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
         #endif
    }

    public void chargerJeu()
    {

    }

    public void ChangerVitesse()
    {
        Menu.Instance.Vitesse = Int32.Parse(saisieVitesse.text);
        
    }

    public void changerAcceleration()
    {
        Menu.Instance.Acceleration = Int32.Parse(saisieAcceleration.text);
    }
}
