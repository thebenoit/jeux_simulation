using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float vitesse = 20f;
    [SerializeField] private float facteurCourse = 1000f;

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
     Debug.Log("Velocity: " + _velocity);
     _controller.Move(vitesseDeplacement * Time.deltaTime);
     
     
    }

    private void ReplacerJoueur()
    {
        //desactiver le controller pendant le respawn
        _controller.enabled = false;
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
}
