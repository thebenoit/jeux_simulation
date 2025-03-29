using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vue_Souris : MonoBehaviour
{
    [SerializeField] private float angleMinimum;
    [SerializeField] private float angleMaximum;

    [SerializeField] private float vitesseRotation;
    
    private GameObject _joueur;

    private float rotationx;

    private float rotationy;
    // Start is called before the first frame update
    void Start()
    {
        _joueur = transform.parent.gameObject;

        rotationx = _joueur.transform.localRotation.eulerAngles.x;
        rotationy = transform.localRotation.eulerAngles.y;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * vitesseRotation;
        rotationy += horizontal;
        _joueur.transform.rotation = Quaternion.Euler(0,rotationy,0);

        //Rotation sur la camera
        float vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * vitesseRotation;
        rotationx -= vertical;
        rotationx = Mathf.Clamp(rotationx, angleMinimum, angleMaximum);
        transform.localRotation = Quaternion.Euler(rotationx, 0, 0);
    }
}
