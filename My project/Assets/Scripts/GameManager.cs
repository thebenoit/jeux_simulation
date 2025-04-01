using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    [SerializeField] private float _vitesese;
    [SerializeField] private float _facteurAcceleration;



    /// <summary>
    /// L'instance statique du singleton
    /// </summary>
    public static GameManager _instance;

    [SerializeField] public float Vitesse{get{return _vitesese;} set{_vitesese = value;}} 
    [SerializeField] public float FacteurAcceleration
    {
        get{return _facteurAcceleration;} 
        set{_facteurAcceleration = value;}
    }

    public static GameManager Instance => _instance;

    //Assure qu'il n'y a qu'une instance du GameManager(ont utilise ce script dans plusieurs scenes)
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void OuvrirMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Déverrouiller et afficher le curseur
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

                       
            // Activer le menu (vous devrez référencer votre menu UI)
            SceneManager.LoadScene("Menu");           
            // Optionnel: mettre le jeu en pause
            Time.timeScale = 0f;
        }
    }

 
    
}
