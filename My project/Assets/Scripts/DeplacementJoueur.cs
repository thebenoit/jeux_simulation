using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float vitesse = 20f;
    [SerializeField] private float facteurCourse = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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

     controller.SimpleMove(vitesseDeplacement);
     
     
    }
}
