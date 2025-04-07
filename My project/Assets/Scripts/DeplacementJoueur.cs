using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeplacementJoueur : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float vitesse;
    [SerializeField] private float facteurCourse;

    private Vector3 _positionInitiale;
    private Quaternion _rotationInitiale;

    float _velocity;
    [SerializeField] float forceSaut = 5f;

   [SerializeField] GameObject _objectif;
    // Start is called before the first frame update
    void Start()
    {

        _controller = GetComponent<CharacterController>();
        _positionInitiale = transform.position;
        _rotationInitiale = transform.rotation;

        vitesse = GameManager.Instance.Vitesse;
        facteurCourse = GameManager.Instance.FacteurAcceleration;

       

        Debug.Log("Vitesse: " + vitesse);
        Debug.Log("FacteurAcceleration: " + facteurCourse);


    }

    // Update is called once per frame
    void Update()
    {
        
     float horizontal = Input.GetAxis("Horizontal");
     float vertical = Input.GetAxis("Vertical");
     float vitesseActuelle = Input.GetKey(KeyCode.LeftShift) ? vitesse * facteurCourse : vitesse;
     


     Vector3 direction = new Vector3(horizontal, 0f, vertical);
     direction = transform.TransformDirection(direction);

     Vector3 vitesseDeplacement = direction * vitesseActuelle;


     bool toucherLeSol = _controller.isGrounded;

     if(toucherLeSol && Input.GetButtonDown("Jump"))
     {
        _velocity = forceSaut;
     }
     else if(toucherLeSol)
     {
        _velocity = 0f;
     }

     _velocity += Physics.gravity.y * Time.deltaTime;

     vitesseDeplacement.y += _velocity;

     //utilisation de simpleMove
     //controller.SimpleMove(vitesseDeplacement);
   
     
     _controller.Move(vitesseDeplacement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Appuyer sur Echap");
            GameManager.Instance.OuvrirMenu();
        }
     
     
    }

    private void ChargerDefaite()
    {
        SceneManager.LoadScene("Defaite");
    }

    private void ReplacerJoueur()
    {
        //desactiver le controller pendant le respawn
        _controller.enabled = false;
        //teleporter le joeur a la position initiale
        transform.position = _positionInitiale;
        transform.rotation = _rotationInitiale;
        _controller.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
    
        if(hit.gameObject == _objectif)
        {
            ReplacerJoueur();
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemi")
        {
            Debug.Log("Toucher un ennemi");
            //ChargerDefaite();
        }
    }
}
 