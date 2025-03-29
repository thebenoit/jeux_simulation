using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float vitesse = 5f;
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

     Vector3 direction = new Vector3(horizontal, 0f, vertical);
     direction = transform.TransformDirection(direction);
     
     Vector3 vitesseDeplacement = direction * vitesse;
     controller.SimpleMove(vitesseDeplacement);
     
     
    }
}
