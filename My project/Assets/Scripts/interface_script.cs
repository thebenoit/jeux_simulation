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
        saisieVitesse.text = Menu.Instance.Acceleration.ToString();
        saisieAcceleration.text = Menu.Instance.Vitesse.ToString();
        Scene scene = SceneManager.GetSceneByName("Labyrynth_2");
        Debug.Log("Scene name: " + scene.name);
        Debug.Log("Is scene loaded? " + scene.isLoaded);

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
        ChangerVitesse();
        ChangerAcceleration();       
        SceneManager.LoadScene("Labyrynth_2");

    }

    public void ChangerVitesse()
    {
        Menu.Instance.Vitesse = Int32.Parse(saisieVitesse.text);
        
    }

    public void ChangerAcceleration()
    {
        Menu.Instance.Acceleration = Int32.Parse(saisieAcceleration.text);
    }
}
