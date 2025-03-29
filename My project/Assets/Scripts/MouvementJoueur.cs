using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
[SerializeField] private float _vitesse;
[SerializeField] private float _forceSaut;
[SerializeField] private float _augmentationCourse = 3;
private CharacterController _characterController;

private Vector3 _positionInitiale;
private Quaternion _rotationInitiale;

private float _velociteY;

[SerializeField] private GameObject _objectif;
private float _courser;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _positionInitiale = transform.position;
        _rotationInitiale = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float magnitudeVitesse = _vitesse;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            magnitudeVitesse *= _augmentationCourse;
        }

        Vector3 direction = new Vector3(horizontal,0,vertical);

        var directionSelonPersonnage = transform.TransformDirection(direction);
         
        Vector3 vitesse = magnitudeVitesse * directionSelonPersonnage;

        
        
    }
}
