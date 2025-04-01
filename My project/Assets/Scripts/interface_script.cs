using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        saisieVitesse.text = GameManager.Instance.FacteurAcceleration.ToString();
        saisieAcceleration.text = GameManager.Instance.Vitesse.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.Instance.FermerMenu();
        }
        
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
        ChangerVitesse();
        ChangerAcceleration();       
        SceneManager.LoadScene("Labyrynth_2");

    }

    public void ChangerVitesse()
    {
        GameManager.Instance.Vitesse = Int32.Parse(saisieVitesse.text);
        
    }

    public void ChangerAcceleration()
    {
        GameManager.Instance.FacteurAcceleration = Int32.Parse(saisieAcceleration.text);
    }
}
